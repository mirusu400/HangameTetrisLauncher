using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace HangameTetrisLauncher
{
    public class CookieAwareWebClient : WebClient
    {

        private CookieContainer container = new CookieContainer();

        protected override WebRequest GetWebRequest(Uri address)
        {
            WebRequest request = base.GetWebRequest(address);
            if (request is HttpWebRequest)
            {
                (request as HttpWebRequest).CookieContainer = container;
            }
            return request;
        }
    }
}
