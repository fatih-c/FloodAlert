using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace FloodAlert
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            WaterStation wtr = new WaterStation();
            FloodAlertDb db = new FloodAlertDb();
          /*  var result1 = db.ObservationData.Where(k => k.id == 1).FirstOrDefault();
            foreach (var item in db.WaterStation)
            {
                gridView.Items.Add(item.Id);
                gridView.Items.Add(item.Name);
            }*/
        }
    }
}
