using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firma.Models;
using SQLite;

namespace Firma.Controlador
{
    public class DataBaseSQLite
    {
        readonly SQLiteAsyncConnection db;
        public DataBaseSQLite(string pathdb)
        {
            db = new SQLiteAsyncConnection(pathdb);
            db.CreateTableAsync<UsuarioFirma>().Wait();
        }

        public DataBaseSQLite()
        {
        }

        public Task<List<UsuarioFirma>> ObtenerListaFirmas()
        {
            return db.Table<UsuarioFirma>().ToListAsync();
        }

        public Task<UsuarioFirma> ObtenerFirmas(int pcodigo)
        {
            return db.Table<UsuarioFirma>()
                .Where(i => i.codigo == pcodigo)
                .FirstOrDefaultAsync();
        }

        public Task<int> GrabarFirmas(UsuarioFirma firmas)
        {
            if (firmas.codigo != 0)
            {
                return db.UpdateAsync(firmas);
            }
            else
            {
                return db.InsertAsync(firmas);
            }

        }
        public Task<int> EliminarFirmas(UsuarioFirma firmas)
        {
            return db.DeleteAsync(firmas);
        }
    }
}
