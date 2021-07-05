using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureDB.Data
{
    public class Foto
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250)]
        public String nombre { get; set; }

        public byte[] image { get; set; }
    }
}
