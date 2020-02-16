using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FloodAlert
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public WaterStation wtr = new WaterStation();
        Settings settings = new Settings();
        public SettingsPage()
        {
            this.InitializeComponent();

            FloodAlertDb db = new FloodAlertDb();
            var result1 = db.Settings.Where(k => k.Id == 1).FirstOrDefault();
            comboBox.PlaceholderText = (result1.Name);
            foreach (var item in db.WaterStation)
            {
                comboBox.Items.Add(item.Name);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FloodAlertDb db = new FloodAlertDb();
            var result1 = db.WaterStation.Where(k => k.Name == Convert.ToString(comboBox.SelectedItem)).FirstOrDefault();
            wtr.Id = result1.Id;
            settings.WaterStationId = wtr.Id;
            settings.Id = 1;
            db.Settings.Remove(settings);
            db.SaveChanges();
            var result2 = db.WaterStation.Where(k => k.Id == wtr.Id).FirstOrDefault();
            settings.Name = result2.Name;
            settings.Id = 1;
            db.Settings.Add(settings);
            db.SaveChanges();
        }
    }
}
