using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Medicapp.Class;
using Medicapp.pag;

namespace Medicapp
{

    public partial class login : ContentPage
    {
        public login()
        {
            InitializeComponent();
        }

     
        private async void   btnlogin_Clicked(object sender, EventArgs e)
        {
           
            try
            {
                if (string.IsNullOrEmpty(email.Text))
                {
                    await DisplayAlert("OUCH", "Debes ingresar un usuario.", "OK");
                    email.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(psw.Text))
                {
                    await DisplayAlert("OUCH", "Debes ingresar clave.", "OK");
                    psw.Focus();
                    return;
                }

                usaermanager manager = new usaermanager();
                var res = await manager.getusers();

                if (res != null)
                {

                    await DisplayAlert("Medicapp", "Bienvenido!! .", "OK");
                    await Navigation.PushAsync(new homelogin());
                }
                else
                {

                    await DisplayAlert("Ouch!!", "Usuario o Clave no son válidos.", "OK");
                    email.Text = string.Empty;
                    psw.Text = string.Empty;
                    email.Focus();
                    psw.Focus();
                    return;

                }
            }
            catch (Exception ex) {
                await DisplayAlert("Ouch!!", "No hay conexión, intente mas tarde.", "OK");

                return;
            }

        }
    }
}