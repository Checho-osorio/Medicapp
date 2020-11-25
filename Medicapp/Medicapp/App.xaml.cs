using Medicapp.pag;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Medicapp
{
    public partial class App : Application
    {
        
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
            MainPage = new F_Registro();
       
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
