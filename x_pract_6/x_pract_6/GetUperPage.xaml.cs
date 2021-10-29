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
    public partial class GetUperPage : ContentPage
    {
        bool isRun = false;
        bool isGetting = false;
        TimeSpan time;
        public GetUperPage()
        {
            InitializeComponent();
            btn_Set.IsEnabled = false;
            btn_Reset.IsEnabled = false;
            timePicker.IsEnabled = false;
            text_TurnOn.Text = "Выключен";
            Device.StartTimer(TimeSpan.FromSeconds(1), TimerTick);
        }

        private void TurnOnGetUpper_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (TurnOnGetUpper.IsChecked)
            {
                btn_Set.IsEnabled = true;
                btn_Reset.IsEnabled = true;
                timePicker.IsEnabled = true;
                isRun = false;
                text_TurnOn.Text = "Включен"; 
            }
            else
            {
                btn_Set.IsEnabled = false;
                btn_Reset.IsEnabled = false;
                timePicker.IsEnabled = false;
                text_TurnOn.Text = "Выключен";
                isRun = false;
            }
        }

        private void btn_Set_Clicked(object sender, EventArgs e)
        {
            time = timePicker.Time;
            timePicker.IsEnabled = false;
            isGetting = false;
            isRun = true;
        }

        private void btn_Reset_Clicked(object sender, EventArgs e)
        {
            time = new TimeSpan(0, 0, 0);
            timePicker.Time = time;
            timePicker.IsEnabled = true;
            isGetting = false;
            isRun = false;
        }

        bool TimerTick()
        {
            if (isRun)
            {
                DateTime d1 = DateTime.Now;
                TimeSpan t1 = new TimeSpan(d1.Hour, d1.Minute, 0);
                if(time.CompareTo(t1) == 0 && !isGetting)
                {
                    isGetting = true;
                    DisplayAlert("Внимание", "Просыпайся", "Ок");                    
                }
            }
            return true;
        }
    }
}