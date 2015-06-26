using AppGlobo.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobo.Banco
{
    class DataBase : DataContext
    {
        public static string DBConnectionString =
                "Data Source = 'isostore:ReceitasDB.sdf'";
        public DataBase()
            : base(DBConnectionString)
        {

        }
        public Table<Favoritos> Favoritosdb
        {
            get { return this.GetTable<Favoritos>(); }
        }
    }
}
