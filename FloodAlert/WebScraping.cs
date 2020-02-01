using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;
using Windows.UI.Popups;
using static System.Net.Mime.MediaTypeNames;
using Windows.ApplicationModel.Core;

namespace FloodAlert
{
    class WebScraping
    {
        
        private readonly WebClient client;
        public string url;
        public WebScraping()
        {
            try
            {
                client = new WebClient();
                url = client.DownloadString("http://www.voda.ba/stanica?stanicabr=109");
                if (url == null)
                {
                    throw new ArgumentNullException();
                }
            }
            
            catch(System.Net.WebException)
            {
                Message();
            }
           
        }
        async void Message()
        {
            await new MessageDialog("No internet connection has been found.", "Message").ShowAsync();
        }
        
    }
}
                  