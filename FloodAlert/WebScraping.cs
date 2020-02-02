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
        WaterStation wtr = new WaterStation();
        FloodAlertDb db = new FloodAlertDb();
        private readonly WebClient client;
        public string url; 
        public WebScraping()
        {
            wtr = db.WaterStation.Where(k => k.Id == wtr.Id).FirstOrDefault();
            try
            {
                client = new WebClient();
                url = client.DownloadString(wtr.Link);
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
                  