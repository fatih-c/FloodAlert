﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloodAlert
{
    class ObservationDownloader
    {
        public List<ObservationData> GetLastObservation(int stationId)
        {
           
            WebScraping file = new WebScraping();
            string html = file.url;
            int ind;
            string level;
            DateTime vrijeme;
            List<ObservationData> data = new List<ObservationData>();
            List<GraphData> graphData = new List<GraphData>();
            ObservationData observationData = new ObservationData();
            GraphData gData = new GraphData();
            observationData.stationId = stationId;
            string format = "dd.MM.yy u HH:mm";
            string substring = "id=\"nivo";
            for (int i = 1; i <= 30; i++)
            {
                ObservationData observationData1 = new ObservationData();
                ind = html.IndexOf(substring + i + "\""); //<td>10.01.20 u 19:00</td>    <td align="right" id="nivo1">100,00 cm </td>
                if (i > 9)
                {
                    level = html.Substring(ind + 26, 3);//9
                    vrijeme = DateTime.ParseExact(html.Substring(ind - 25, 16), format, CultureInfo.CurrentCulture);
                }
                else
                {
                    level = html.Substring(ind + 25, 3);
                    vrijeme = DateTime.ParseExact(html.Substring(ind - 25, 16), format, CultureInfo.CurrentCulture);
                }
                observationData1.waterLevel = Convert.ToInt32(level);
                observationData1.measuringTime = vrijeme;
                DateTime time = DateTime.Now;
                observationData1.processingTime = time;
                //observationData1.id = i;
                observationData1.stationId = 1;
                data.Add(observationData1);

            }
            return data;
        }
    }
}
