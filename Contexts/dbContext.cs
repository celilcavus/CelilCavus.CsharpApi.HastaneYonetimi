using CelilCavus.Interfaces;
using MySql.Data.MySqlClient;

namespace CelilCavus.Contexts
{
    public class dbContext:IBaseDbContext
    {
        private  MySqlConnection connection = new MySqlConnection("Server=root;Port=3306;Database=hospitaldb;Uid=celil;Pwd=celil123;");
        public  MySqlConnection Context 
        { get => connection; set => value = connection; }

    }
}