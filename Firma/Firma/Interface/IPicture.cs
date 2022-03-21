using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Firma.Interface
{
    public interface IPicture
    {
        bool GuardarImagen(Stream data);
    }
}
