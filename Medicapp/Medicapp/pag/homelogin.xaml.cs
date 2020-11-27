using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Medicapp.pag
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class homelogin : ContentPage
    {
        public homelogin()
        {
            InitializeComponent();
        }

        private async void btnconsulta_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new consulta_med());
        }

        private async Task btnregistrar_ClickedAsync(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new registro_med());
        }
    }
}