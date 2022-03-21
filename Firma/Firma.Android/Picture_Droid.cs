using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Firma.Droid;
using Firma.Interface;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(Picture_Droid))]
namespace Firma.Droid
{
    public class Picture_Droid : IPicture
    {

        public bool GuardarImagen(Stream data)
        {
            if (MainActivity.Instance.CheckSelfPermission(Manifest.Permission.WriteExternalStorage) == Android.Content.PM.Permission.Granted)
            {
                DateTime date = DateTime.Now;
                string filename = "Imagen" + date.Year.ToString() + date.Month.ToString() + date.Day.ToString() + date.Second.ToString() + date.Millisecond.ToString() + ".jpg";
                var documentsPath = Android.App.Application.Context.GetExternalFilesDir("").AbsolutePath;
                
                documentsPath = Path.Combine(documentsPath, "Imagenes_Firmas");
                Directory.CreateDirectory(documentsPath);

                string filePath = Path.Combine(documentsPath, filename);

                byte[] bArray = new byte[data.Length];
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    using (data)
                    {
                        data.Read(bArray, 0, (int)data.Length);
                    }
                    int length = bArray.Length;
                    fs.Write(bArray, 0, length);
                }
                return true;
            }
            else
            {
                MainActivity.Instance.RequestPermissions(new string[] { Manifest.Permission.WriteExternalStorage }, 0);
                return false;
            }

        }
    }
}