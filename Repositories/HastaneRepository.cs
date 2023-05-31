using CelilCavus.Entites;
using CelilCavus.enums;
using CelilCavus.Interfaces;
using Dapper;

namespace CelilCavus.Repositories
{
    public class HastaneRepository : IRepository<Hastane>
    {
        private readonly IBaseDbContext _context;

        public HastaneRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public void Add(Hastane item)
        {
            _context.Context.Execute($@"INSERT INTO {TableName.Hastane} 
            (hastaneAdi,hastaneTel,hastaneAdress,hastaneMail) values
             ('{item.HastaneAdi}','{item.HastaneTel}','{item.HastaneAdress}','{item.HastaneMail}')");
        }

        public List<Hastane> GetAll() =>
         _context.Context.Query<Hastane>($"SELECT * FROM {TableName.Hastane}").ToList();

        public Hastane GetById(int id) =>
         _context.Context.QueryFirst<Hastane>($"SELECT * FROM {TableName.Hastane} WHERE Id = {id}");

        public void Remove(int id) => _context.Context.Execute($"DELETE FROM {TableName.Hastane} WHERE Id = {id}");

        public void Update(Hastane item)
        {
           _context.Context.Execute($@"
            UPDATE {TableName.Hastane}  SET
            hastaneAdi = '{item.HastaneAdi}',
            hastaneTel = '{item.HastaneTel}',
            hastaneAdress = '{item.HastaneAdress}',
            hastaneMail = '{item.HastaneMail}'
            WHERE Id = {item.Id}");
        }
    }
}