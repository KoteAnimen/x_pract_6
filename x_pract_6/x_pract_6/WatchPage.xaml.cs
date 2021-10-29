using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace x_pract_6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchPage : ContentPage
    {
        public WatchPage()
        {
            InitializeComponent();
            time_Time.Text = DateTime.Now.ToString("    HH:mm");
            date_Date.Text = DateTime.Now.ToString("dd.MM.yyyy");
            Device.StartTimer(TimeSpan.FromSeconds(1), TimeUpdate);
        }

        private bool TimeUpdate()
        {
            time_Time.Text = DateTime.Now.ToString("    HH:mm");
            date_Date.Text = DateTime.Now.ToString("dd.MM.yyyy");
            return true; 
        }
    }
}