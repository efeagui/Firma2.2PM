using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Interface;
using Firma.Views;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using Xamarin.Forms.PlatformConfiguration;
using System.ComponentModel;

namespace Firma.Views
{
    public partial class Pagefirma : ContentPage
    {
        string base64Val;
        public Pagefirma()
        {
            InitializeComponent();
        }

    public async void Informacion()
        {
            var firma = new Models.UsuarioFirma
            {
                base_64 = base64Val,
                nombre = txtNombre.Text,
                descripcion = txtDescripcion.Text
            };

            var resultado = await App.BaseDatos.GrabarFirmas(firma);

            if (resultado == 1)
            {
                await DisplayAlert("Mensaje", "Registro exitoso!!!", "ok");
                txtDescripcion.Text = txtNombre.Text = base64Val = String.Empty;
                signature.Clear();
            }
            else
            {
                await DisplayAlert("Error", "No se pudo Guardar", "ok");
            }
        }

        public static async Task WriteStreamAsync(string path, Stream contents)
        {
            using (var writer = File.Create(path))
            {
                await contents.CopyToAsync(writer).ConfigureAwait(false);
            }
        }

        private async void btnSubmit_Clicked(object sender, EventArgs e)
        {
            try
            {
                var image = await signature.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png);
                var mStream = (MemoryStream)image;
                byte[] data = mStream.ToArray();
                base64Val = Convert.ToBase64String(data);

                var SeGuardoImagen = DependencyService.Get<IPicture>().GuardarImagen(mStream);
                if (SeGuardoImagen == true)
                {
                    bool ver = false;
                    if (String.IsNullOrWhiteSpace(txtDescripcion.Text) == true || String.IsNullOrWhiteSpace(txtNombre.Text) == true)
                    {
                        await DisplayAlert("Error", "Debera llenar todos los campos Vacios", "Ok");
                    }
                    else
                    {
                        Informacion();
                    }

                }
                else
                {
                    await DisplayAlert("Alerta", "No Guarda, Dar los permisos de imagen en la app", "ok");
                }

            }
            catch (Exception ex)
            {

                await DisplayAlert("Error", "Porfavor Digite su Firma", "Ok");
            }
        }

        private async void btnlist_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MostrarFirma());
        }
    }
}