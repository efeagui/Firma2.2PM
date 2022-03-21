using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Firma.Views;
using System.IO;
using Firma.Controlador;

namespace Firma
{
    public partial class App : Application
    {
        static DataBaseSQLite basedatos;
        public static DataBaseSQLite BaseDatos
        {
            get
            {
                if (basedatos == null)
                {
                    basedatos = new DataBaseSQLite(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "firmas.db3"));
                }


                return basedatos;
            }

        }
        public App()
        {
            InitializeComponent();
           // MainPage = new Pagefirma();
            MainPage = new NavigationPage(new Pagefirma());
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
