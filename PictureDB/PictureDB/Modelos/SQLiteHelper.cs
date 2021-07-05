using PictureDB.Data;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PictureDB.Modelos
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;

        public SQLiteHelper( string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Foto>().Wait();
        }

        //Guardar Datos
        public Task<int> SaveFotoAsync(Foto fotos)
        {
            if (fotos.id != 0)
            {
                return db.UpdateAsync(fotos);
            }
            else
            {
                return db.InsertAsync(fotos);
            }
        }

        //Muestar todos los datos de la BD
        public Task<List<Foto>> GetFotoAsync()
        {
            return db.Table<Foto>().ToListAsync();
        }

        //Muestar todos los datos de la BD por ID
        public Task<Foto> GetFotoByIdAsync(int id)
        {
            return db.Table<Foto>().Where(a => a.id == id).FirstOrDefaultAsync();
        }

        //Borrar datos
        public Task<int> DeleteFotoAsync(Foto fotos)
        {
            return db.DeleteAsync(fotos);
        }

    }
}
