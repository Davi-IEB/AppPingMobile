using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPingMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new SetEmpresas())
            {
                BarTextColor = Color.Black,
            };
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
