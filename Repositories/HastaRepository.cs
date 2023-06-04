using CelilCavus.Entites;
using CelilCavus.enums;
using CelilCavus.Interfaces;
using Dapper;

namespace CelilCavus.Repositories
{
    public class HastaRepository : IRepository<Hasta>
    {
        private readonly IBaseDbContext _context;
        private readonly string TblName = TableName.hasta.ToString();

        public HastaRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public void Add(Hasta item)
        {
            _context.Context.Execute($@"
            Insert into {TblName}
            (HastaAdi,Telefon,Adress,PolikinlikAdi)
            values ('{item.HastaAdi}','{item.Telefon}','{item.Adress}','{item.PolikinlikAdi}') ");
        }

        public List<Hasta> GetAll() => _context.Context.Query<Hasta>($"SELECT * FROM {TblName}").ToList();

        public Hasta GetById(int id) => _context.Context.QuerySingleOrDefault<Hasta>($"SELECT * FROM {TblName} WHERE Id = {id}");

        public void Remove(int id) => _context.Context.Execute($"DELETE FROM {TblName} WHERE Id = {id}");

        public void Update(Hasta item)
        {
            _context.Context.Execute($@"
            UPDATE  {TblName} SET
            HastaAdi = '{item.HastaAdi}',
            Telefon = '{item.Telefon}',
            Adress = '{item.Adress}',
            PolikinlikAdi = '{item.PolikinlikAdi}'
            WHERE Id = {item.Id}");
        }
    }
}