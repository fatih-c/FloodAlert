using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FloodAlert
{
    public sealed partial class MainPage : Page
    {
        private Timer timer;
        void ShowMessage()
        {
            textBlock.Text = ("ERROR: Ne mozemo pristupiti podacima! "+ DateTime.Now.ToString("HH:mm"));
        }
        void DbMesssage(string message)
        {
            textBlock.Text = ("ERROR: Ne mozemo pristupiti bazi! "+ message + DateTime.Now.ToString("HH:mm")); ;
        }
        //await new MessageDialog("Your message here", "Title of the message dialog").ShowAsync();
        public MainPage()
        {
            this.InitializeComponent();
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, "FloodAlert.db");
            try
            {
                ShowData();
            }
            catch(ArgumentNullException)
            {
                ShowMessage();
                
                timer = new Timer(timerCallback, null, (int)TimeSpan.FromMinutes(0.3).TotalMilliseconds, Timeout.Infinite);
            }


            timer = new Timer(timerCallback, null, (int)TimeSpan.FromMinutes(10).TotalMilliseconds, Timeout.Infinite);
            #region stari kod
            //listView.Items.Add(observationData.Count);
            /* ObservationData data = new ObservationData();
             data.stationId = 109;
             WebScraping file = new WebScraping();             
             string html = file.url;
             int ind;
             string level;
             DateTime vrijeme;
             string format = "dd.MM.yy u HH:mm";          
             string substring = "id=\"nivo";
             for (int i = 1; i<=30; i++)
             {

                 ind = html.IndexOf(substring + i + "\""); //<td>10.01.20 u 19:00</td>    <td align="right" id="nivo1">100,00 cm </td>
                 if (i > 9)
                 {
                     level = html.Substring(ind + 26, 9);
                     vrijeme = DateTime.ParseExact(html.Substring(ind - 25, 16), format, CultureInfo.CurrentCulture);
                 }
                 else
                 {
                     level = html.Substring(ind + 25, 9);
                     vrijeme = DateTime.ParseExact(html.Substring(ind - 25, 16), format, CultureInfo.CurrentCulture);
                 }
                 FloodAlertDb db = new FloodAlertDb();

                 listView.Items.Add(vrijeme.ToString("dd.MM u HH:mm")+ "    " + level);


             }*/
            // txtBox1.Text = lista;
            /* int ind = html.IndexOf("id=\"nivo1\""); //<td>10.01.20 u 19:00</td>    <td align="right" id="nivo1">100,00 cm </td>
             string level = html.Substring(ind+25, 9);
             string vrijeme = html.Substring(ind - 25, 16);
             txtBox1.Text = vrijeme + "    " + level;*/
            #endregion
        }
        private async void timerCallback(object state)
        {

            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
          () => {
              try
              {
                  ShowData();
                  textBlock.Text = "";
              }
              catch(Exception)
              {
                  ShowMessage();
                  timer = new Timer(timerCallback, null, (int)TimeSpan.FromMinutes(10).TotalMilliseconds, Timeout.Infinite);
              }
          });

        }
        void ShowData()
        {

            ObservationDownloader observation = new ObservationDownloader();
            int stationId = 1;
          
            List<ObservationData> observationData = observation.GetLastObservation(stationId);
            ObservationData data = new ObservationData();
            FloodAlertDb db = new FloodAlertDb();
            foreach (var item in observationData)
            {
                listView.Items.Add(item.measuringTime.ToString("dd.MM u HH:mm"));
                listView.Items.Add(item.waterLevel);
                data = item;             
                try
                {
                    db.ObservationData.Add(data);
                    db.SaveChanges();
                }
                                     
               
                catch (Exception)
                {
                    
                }
            }
            


            AddChart(observationData);
            textBox.Text = observationData[0].processingTime.ToString("HH:mm");
            textBox1.Text = observationData[0].waterLevel.ToString();
            
        }
        private void AddChart(List<ObservationData> observationData)
        {
           
            List<GraphData> list = new List<GraphData>();
            GraphData data1 = new GraphData();
            for (int i = 0; i < 30; i++)
            {
                data1.waterLevel = observationData[i].waterLevel;
                data1.measuringTime = observationData[i].measuringTime.ToString("HH:mm");
                list.Add(data1);
            }
            //(lineChart.Series[0] as LineSeries).ItemsSource = list;
        }
         
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
