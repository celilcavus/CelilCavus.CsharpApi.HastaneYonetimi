using CelilCavus.Interfaces;
using MySql.Data.MySqlClient;

namespace CelilCavus.Contexts
{
    public class dbContext:IBaseDbContext
    {
        // private  MySqlConnection connection = new MySqlConnection();
        public const string connection = "Host=localhost;Port=3306;Database=hospitaldb;Uid=root;Pwd=celil123;";
        public const string connection2 = "Server=root;Port=3306;Database=hospitaldb;Uid=celil;Pwd=celil123";
        public MySqlConnection Context { get; set;} = new MySqlConnection(connection);

    }
}