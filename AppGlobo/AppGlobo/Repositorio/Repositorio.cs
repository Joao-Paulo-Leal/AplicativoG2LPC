using AppGlobo.Banco;
using AppGlobo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGlobo.Repositorio
{
    public class Repositorio
    {

        private static DataBase GetDataBase()
        {
            DataBase db = new DataBase();
            if (!db.DatabaseExists())
                db.CreateDatabase();

            return db;
        }
        public static List<Favoritos> Get()
        {
            DataBase db = GetDataBase();
            var query = from Fav in db.Favoritosdb orderby Fav.idB select Fav;

            List<Favoritos> favor = new List<Favoritos>(query.AsEnumerable());
            return favor;

        }
        public static void Adicionar(Favoritos Afavorito)
        {
            DataBase db = GetDataBase();
            db.Favoritosdb.InsertOnSubmit(Afavorito);
            db.SubmitChanges();
        }
        public static void Delete(Favoritos Afavorito)
        {
            DataBase db = GetDataBase();
            var query = from c in db.Favoritosdb
                        where c.idB == Afavorito.idB
                        select c;
            db.Favoritosdb.DeleteOnSubmit(query.ToList()[0]);
            db.SubmitChanges();

        }



    }
}
