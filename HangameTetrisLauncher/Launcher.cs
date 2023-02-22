using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Net.Sockets;

namespace HangameTetrisLauncher
{
    class Launcher
    {
        public byte[] HexToBin(string hex)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < hex.Length; i+=2)
            {
                var b = byte.Parse(hex.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                bytes.Add(b);
            }

            return bytes.ToArray();
        }

        public string Bin2Hex(byte[] hex)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < hex.Length; i++)
            {
                var c = hex[i].ToString("x2");
                s.Append(c);
            }

            return s.ToString();
        }

        public void StartHangame(string login, string pass, string chan, bool SkipUpdater)
        {
            System.Net.ServicePointManager.Expect100Continue = false;

            CookieAwareWebClient wc = new CookieAwareWebClient();

            var key = wc.DownloadData("http://lform.hangame.com/key/keys_jsonp_jindo.php");
            var keys = Encoding.ASCII.GetString(key);

            Regex reg = new Regex("\"(.*)\"");
            var keydata = reg.Match(keys).Result("$1");
            var keydatas = keydata.Split(',');

            //var session = "dkSWbm7XFrHWMEl4";
            //var keyname = "100006265";
            //var modulus = "52fd0edd682298274ae716ec23e3af4f870db222ed8ee6d0b588d894b4e8998d17a99262bee6d3a8d8421f0304b62b1f2a89bbb11729d526c888ea573f966407832156c30f87723dacdb99dec907564643f40465e179c7542d7228543afa9aefd1d80a2fd7";
            //var exp = "010001";

            var session = keydatas[0];
            var keyname = keydatas[1];
            var modulus = keydatas[2];
            var exp = keydatas[3];

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();

            RSAParameters para = new RSAParameters();
            para.Modulus = HexToBin(modulus);
            para.Exponent = HexToBin(exp);
            rsa.ImportParameters(para);

            var loginb64 = System.Convert.ToBase64String(Encoding.ASCII.GetBytes(login));

            string credstring = "";
            credstring += (char)session.Length;
            credstring += session;
            credstring += (char)loginb64.Length;
            credstring += loginb64;
            credstring += (char)pass.Length;
            credstring += pass;

            var credstringb = Encoding.UTF8.GetBytes(credstring);
            var credenc = rsa.Encrypt(credstringb, false);

            var turtle = Bin2Hex(credenc);

            wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            //string data = String.Format("nxtURL=http%3A%2F%2Ftetris.hangame.com%2Findex.nhn&hanilogin=N&force=Y&hani=&svctype=publishing&strmemberid={0}&formencoding=UTF-8&strmemberid_input=Jhyunjin08&strpassword={1}&ssl=on",login,pass);
            string data = String.Format("nxtURL=http%3A%2F%2Ftetris.hangame.com%2F&from=&info=&seqno=&popup=&popclose=&closemove=&turtle={0}&keyname={1}&earthworm=earthworm&seculogin=true&hanilogin=N&force=Y&renewal=Y&secukey=&secutype=2&strjumin1=&strjumin2=&strjumin=&strname=&ipinreqnum=&bartype=1.9629629629629628&turtle2=&earthworm2=",
                turtle, keyname);

            //wc.UploadData("https://pubids.hangame.com/login.nhn", "POST", Encoding.ASCII.GetBytes(data));
            var idres = wc.UploadData("http://id.hangame.com/login.nhn", "POST", Encoding.ASCII.GetBytes(data));
            var idress = Encoding.UTF8.GetString(idres);

            byte[] res = wc.DownloadData(String.Format("http://tetris.hangame.com/gamestart.nhn?m=getGSTR&subid={0}&isTest=y&isObs={1}", chan, "false"));
            string r = Encoding.ASCII.GetString(res);

            Regex str = new Regex("^this.str=\"(?<rrr>.*)\";\\r$", RegexOptions.Multiline);
            Regex result = new Regex("^this.result=\"(?<rrr>.*)\";\\r$", RegexOptions.Multiline);
            Regex err = new Regex("^this.errCode=\"(?<rrr>.*)\";\\r$", RegexOptions.Multiline);

            string ress = result.Match(r).Result("${rrr}");

            if (ress == "success")
            {
                string arg = str.Match(r).Result("${rrr}");

                if (!SkipUpdater)
                {
                    //string file = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Hangame\hgstarter.exe");
                    string file = "HGStart19.exe";
                    
                    //Console.WriteLine(arg);
                    Process.Start(file, arg);
                }
                else
                {
                    RegistryKey hanReg = Registry.CurrentUser.OpenSubKey(@"Software\HanGame.Com\KOREAN");
                    var p = hanReg.GetValue("Home") as string;

                    string file = "Tet4.exe";
                    var tetArgf = GetClientArg(arg);

                    var cd = Directory.GetCurrentDirectory();

                    //tetArgf = tetArgf.Replace("119.205.241.222", "127.0.0.1"); //change lobby server

                    Directory.SetCurrentDirectory(p);
                    Process.Start(file, tetArgf);

                    Directory.SetCurrentDirectory(cd);
                }
            }
            else
            {
                string ec = err.Match(r).Result("${rrr}");
                throw new Exception(ec);
            }
        }

        private string GetClientArg(string arg)
        {
            var r = Regex.Match(arg, @"^hangame://http://(?<host>(\w|\.)+):(?<port>\d+)(?<param>\?.*)$");

            var host = r.Result("${host}");
            var port = int.Parse(r.Result("${port}"));
            var param = r.Result("${param}");

            //this server do not return valid http response so we have to handle it manually

            TcpClient tcp = new TcpClient(host, port);

            var c = "GET /" + param + " HTTP/1.1\r\n" + "Host: gss.casual.hangame.com\r\n" + "\r\n";
            List<byte> h = new List<byte>();

            tcp.Client.Send(Encoding.ASCII.GetBytes(c));

            int i;

            do
            {
                byte[] buffer = new byte[256];
                i = tcp.Client.Receive(buffer);
                h.AddRange(buffer);
            }
            while (i > 0);

            tcp.Close();

            var tetArgs = Encoding.Default.GetString(h.ToArray());

            var tetArgf = tetArgs.TrimEnd('\0', '\r').Replace("hangame://", "");
            return tetArgf;
        }
    }
}
