using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firma.Controlador;
using Firma.Models;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Firma.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MostrarFirma : ContentPage
    {
        private object imgsignature;

        public MostrarFirma()
        {
            InitializeComponent();
            cargarListado();
        }
        public async void cargarListado()
        {
            var lista = await App.BaseDatos.ObtenerListaFirmas();
            listastfirmas.ItemsSource = lista;
        }
        private void lstfirmas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listastfirmas.SelectedItem = null;
        }
       
        

    }
}