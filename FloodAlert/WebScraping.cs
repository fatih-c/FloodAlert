using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;

namespace FloodAlert
{
    class WebScraping
    {
        private readonly WebClient client;
        public string url;

        public WebScraping()
        {
            client = new WebClient();
            url = client.DownloadString("http://www.voda.ba/stanica?stanicabr=109");
        }
       
    }
}
                  