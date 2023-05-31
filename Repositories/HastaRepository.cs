using CelilCavus.Entites;
using CelilCavus.enums;
using CelilCavus.Interfaces;
using Dapper;

namespace CelilCavus.Repositories
{
    public class HastaRepository : IRepository<Hasta>
    {
        private readonly IBaseDbContext _context;

        public HastaRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public void Add(Hasta item)
        {
            _context.Context.Execute($@"
            Insert into {TableName.Hasta}
            (HastaAdi,Telefon,Adress,PolikinlikAdi)
            values ('{item.HastaAdi}','{item.Telefon}','{item.Adress}','{item.PolikinlikAdi}') ");
        }

        public List<Hasta> GetAll() => _context.Context.Query<Hasta>($"SELECT * FROM {TableName.Hasta}").ToList();

        public Hasta GetById(int id) => _context.Context.QuerySingleOrDefault<Hasta>($"SELECT * FROM {TableName.Hasta} WHERE Id = {id}");

        public void Remove(int id) => _context.Context.Execute($"DELETE FROM {TableName.Hasta} WHERE Id = {id}");

        public void Update(Hasta item)
        {
            _context.Context.Execute($@"
            UPDATE  {TableName.Hasta} SET
            HastaAdi = '{item.HastaAdi}',
            Telefon = '{item.Telefon}',
            Adress = '{item.Adress}',
            PolikinlikAdi = '{item.PolikinlikAdi}'
            WHERE Id = {item.Id}");
        }
    }
}