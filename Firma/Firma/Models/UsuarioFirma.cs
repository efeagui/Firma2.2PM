using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Firma.Models
{
    public class UsuarioFirma
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public string base_64 { get; set; }

        [MaxLength(200)]
        public string nombre { get; set; }

        [MaxLength(200)]
        public string descripcion { get; set; }
    }
}
