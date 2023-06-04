using CelilCavus.Entites;
using CelilCavus.enums;
using CelilCavus.Interfaces;
using Dapper;

namespace CelilCavus.Repositories
{
    public class TedaviRepository : IRepository<Tedavi>
    {
        private readonly IBaseDbContext _context;

        private readonly string TblName = TableName.tedavi.ToString();
        
        public TedaviRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public void Add(Tedavi item)
        {
            _context.Context.Execute($@"INSERT INTO {TblName} 
            (TedaviNo,HastaneAdi,DoktorAdi,HastaAdi,PolikinlikAdi,TedaviTarihi,Ucret) values
            (
                '{item.TedaviNo}',
                '{item.HastaneAdi}',
                '{item.DoktorAdi}',
                '{item.HastaAdi}',
                '{item.PolikinlikAdi}',
                '{item.TedaviTarihi}',
                '{item.Ucret}'
            )
            ");
        }

        public List<Tedavi> GetAll()
        {
            return _context.Context.Query<Tedavi>($"SELECT * FROM {TblName}").ToList();
        }

        public Tedavi GetById(int id) => _context.Context.QueryFirstOrDefault<Tedavi>($@"SELECT * FROM {TblName} WHERE Id = {id}");

        public void Remove(int id) => _context.Context.Execute($"DELETE FROM {TblName}");

        public void Update(Tedavi item)
        {
            _context.Context.Execute($@"UPDATE {TblName} SET 
            TedaviNo =  '{item.TedaviNo}',
            HastaneAdi = '{item.HastaneAdi}',
            DoktorAdi = '{item.DoktorAdi}',
            HastaAdi = '{item.HastaAdi}',
            PolikinlikAdi = '{item.PolikinlikAdi}',
            TedaviTarihi = '{item.TedaviTarihi}',
            Ucret '{item.Ucret}'
            WHERE Id = {item.Id}
            ");
        }
    }
}