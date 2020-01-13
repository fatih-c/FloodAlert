﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Globalization;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FloodAlert
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
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
                listView.Items.Add(vrijeme.ToString("dd.MM u HH:mm")+ "    " + level);
                 
                
            }
           // txtBox1.Text = lista;
           /* int ind = html.IndexOf("id=\"nivo1\""); //<td>10.01.20 u 19:00</td>    <td align="right" id="nivo1">100,00 cm </td>
            string level = html.Substring(ind+25, 9);
            string vrijeme = html.Substring(ind - 25, 16);
            txtBox1.Text = vrijeme + "    " + level;*/
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
