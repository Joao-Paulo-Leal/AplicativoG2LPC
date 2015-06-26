using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobo.Entidades
{
    [Table(Name = "Favorito")]
    public class Favoritos
    {
        [Column(IsPrimaryKey = true, IsDbGenerated = true, DbType = "INT NOT NULL Identity", AutoSync = AutoSync.OnInsert, CanBeNull = false)]
        public int idB { get; set; }
        [Column(CanBeNull = true)]
        public string titleB { get; set; }
        [Column(CanBeNull = true)]
        public string pubDateB { get; set; }
        [Column(CanBeNull = true)]
        public string descriptionB { get; set; }
        [Column(CanBeNull = true)]
        public string linkB { get; set; }
    }
}
