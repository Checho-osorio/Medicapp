using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.ComponentModel;

using Medicapp.Class;
using Medicapp.pag;

namespace Medicapp
{

    public partial class login : ContentPage
    {
        const string URL = "http://192.168.0.4/WebServiceXamarin/listado.php";
        private static HttpClient getClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");

            return client;
        }

        private static async Task<IEnumerable<user>> getusers()
        {
            HttpClient client = getClient();

            var res = await client.GetAsync(URL);
            
            if (res.IsSuccessStatusCode)
            {
                string content = await res.Content.ReadAsStringAsync();
               
                
                return JsonConvert.DeserializeObject<IEnumerable<user>>(content);

            }

            return Enumerable.Empty<user>();
        }


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


                var data = res.Content.ReadAsStringAsync().Result;
                var deviceUser = JsonConvert.DeserializeObject<user>(data);

                if (deviceUser.correo == email.Text && deviceUser.psw == psw.Text)
                {
                    // ((NavigationPage)this.Parent).PushAsync(new loginhome());
                    await DisplayAlert("Ouch!!", "login ok.", "OK");

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