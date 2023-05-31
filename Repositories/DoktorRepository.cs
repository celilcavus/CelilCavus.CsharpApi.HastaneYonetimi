using CelilCavus.Entites;
using CelilCavus.enums;
using CelilCavus.Interfaces;
using Dapper;

namespace CelilCavus.Repositories
{
    public class DoktorRepository : IRepository<Doktor>
    {
        private readonly IBaseDbContext _context;

        public DoktorRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public void Add(Doktor item)
        {
           _context.Context.Execute($@"INSERT INTO {TableName.Doktor}
            (DoktorAdi,UzmanlikAlani,Telefon,Eposta,CalistigiHastnae values
             ('{item.DoktorAdi}',
             '{item.UzmanlikAlani}',
             '{item.Telefon}',
             '{item.Eposta}',
             '{item.CalistigiHastnae}'
             )");
        }

        public List<Doktor> GetAll()
        {
           return _context.Context.Query<Doktor>($"SELECT * FROM {TableName.Doktor}").ToList();
        }

        public Doktor GetById(int id)
        {
            return _context.Context.QueryFirstOrDefault<Doktor>($"SELECT * FROM {TableName.Doktor} WHERE Id = {id}");
        }

        public void Remove(int id)
        {
           _context.Context.Execute($"DELETE FROM {TableName.Doktor} WHERE Id = {id}");
        }

        public void Update(Doktor item)
        {
            _context.Context.Execute($@"UPDATE {TableName.Doktor} SET
            DoktorAdi = '{item.DoktorAdi}',
            UzmanlikAlani = '{item.UzmanlikAlani}',
            Telefon = '{item.Telefon}',
            Eposta = '{item.Eposta}',
            CalistigiHastnae =  '{item.CalistigiHastnae}'
            WHERE Id = {item.Id}");
        }
    }
}