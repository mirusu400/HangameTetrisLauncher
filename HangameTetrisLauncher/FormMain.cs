using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;

namespace HangameTetrisLauncher
{
    public partial class FormMain : Form
    {
        private string configFile = "HangameTetrisLauncher.cfg";
        private bool optionsToggle = false;

        string[]  chanIds = { "0015" ,"0005", "0000", "0010", "0020", "0030", "0035", "0040",
                                "0050", "0060", "0080", "0085", "0090", "01D0", "0095A"};

        string[] chanNames = { "inferior" ,"firster", "beginner", "amateur", "senior", "semipro", "pro", "masters",
                                "champion", "royal", "heaven", "god", "free", "training", "tera"};

        public FormMain()
        {
            InitializeComponent();
        }

        private void bStart_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void Start()
        {
            Cursor = Cursors.WaitCursor;

            try
            {
                Launcher l = new Launcher();

                l.StartHangame(tbID.Text, tbPassword.Text, chanIds[cbChannel.SelectedIndex], cbSkip.Checked);

                SaveConfig();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

            Cursor = Cursors.Default;
        }

        private void bExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveConfig()
        {
            try
            {
                StreamWriter sw = new StreamWriter(configFile);

                if (rRemID.Checked || rRemIDPass.Checked || rAutoLogin.Checked)
                    sw.WriteLine(tbID.Text);
                else
                    sw.WriteLine();

                if (rRemIDPass.Checked || rAutoLogin.Checked)
                    sw.WriteLine(tbPassword.Text);
                else
                    sw.WriteLine();

                sw.WriteLine(chanIds[cbChannel.SelectedIndex]);

                if (rRemIDPass.Checked)
                    sw.WriteLine(2);
                else if (rRemID.Checked)
                    sw.WriteLine(1);
                else if (rAutoLogin.Checked)
                    sw.WriteLine(3);
                else // (rRemNothing.Checked)
                    sw.WriteLine(0);

                sw.WriteLine(cbSkip.Checked);

                sw.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void ReadConfig()
        {
            try
            {
                StreamReader sr = new StreamReader(configFile);

                tbID.Text = sr.ReadLine();
                tbPassword.Text = sr.ReadLine();

                var channel = sr.ReadLine();

                var chanIndex = Array.IndexOf(chanIds, channel);

                if (chanIndex >= 0)
                    cbChannel.SelectedIndex = chanIndex;

                int rem = int.Parse(sr.ReadLine());

                if (rem == 2)
                    rRemIDPass.Checked = true;
                else if (rem == 1)
                    rRemID.Checked = true;
                else if (rem == 3)
                    rAutoLogin.Checked = true;
                else if (rem == 0)
                    rRemNothing.Checked = true;
                else
                    throw new Exception("Invalid value");

                if (!sr.EndOfStream)
                    cbSkip.Checked = bool.Parse(sr.ReadLine());

                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            cbChannel.Items.AddRange(chanNames);
            cbChannel.SelectedIndex = 0;

            if (File.Exists(configFile))
                ReadConfig();

            if (tbID.Text == "")
                (tbID as Control).Select();
            else
                (tbPassword as Control).Select();

            if (Registry.CurrentUser.OpenSubKey(@"Software\HanGame.Com\KOREAN") == null)
            {
                cbSkip.Checked = false;
                cbSkip.Enabled = false;
            }

            ShowHideOptions();

            if (rAutoLogin.Checked)
                Start();
        }

        private void bOptions_Click(object sender, EventArgs e)
        {
            optionsToggle = !optionsToggle;
            ShowHideOptions();
        }

        private void ShowHideOptions()
        {
            if (optionsToggle)
                ClientSize = new Size(ClientSize.Width, cbSkip.Bottom + 15);
            else
                ClientSize = new Size(ClientSize.Width, bOptions.Bottom + 15);

            gbRemember.Visible = optionsToggle;
        }

        private void rAutoLogin_Click(object sender, EventArgs e)
        {
            if (rAutoLogin.Checked)
                MessageBox.Show(this, String.Format("You wont see login screen again. To disable auto login in future you will have to delete {0} or edit it manually.", configFile));
        }
    }
}