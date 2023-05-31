using MySql.Data.MySqlClient;

namespace CelilCavus.Interfaces
{
    public interface IBaseDbContext
    {
        public  MySqlConnection Context { get; set; }
    }
}