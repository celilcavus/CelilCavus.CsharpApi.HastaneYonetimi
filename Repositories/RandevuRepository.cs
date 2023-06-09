using CelilCavus.Entites;
using CelilCavus.enums;
using CelilCavus.Interfaces;
using Dapper;

namespace CelilCavus.Repositories
{
    public class RandevuRepository : IRepository<Randevu>
    {
        private readonly IBaseDbContext _context;
        private readonly string TblName = TableName.randevu.ToString();

        public RandevuRepository(IBaseDbContext context)
        {
            _context = context;
        }

        public void Add(Randevu item)
        {
            string sql = $@"INSERT INTO {TblName} 
            (RandevuNo,HastaAdi,PolikinlikAdi,RandevuTarihi,DoktorAdi)
            values 
            ('{item.RandevuNo}','{item.HastaAdi}','{item.PolikinlikAdi}','{item.RandevuTarihi}','{item.DoktorAdi}')";
            
            _context.Context.Execute(sql);
        }

        public List<Randevu> GetAll() => _context.Context.Query<Randevu>($"SELECT * FROM {TblName}").ToList();

        public Randevu GetById(int id) => _context.Context.QuerySingleOrDefault<Randevu>($"SELECT * FROM {TblName}");

        public void Remove(int id) => _context.Context.Execute($"DELETE FROM {TblName}");

        public void Update(Randevu item)
        {
                string sql = $@"
                UPDATE {TblName} SET 
                RandevuNo = '{item.RandevuNo}',
                HastaAdi ='{item.HastaAdi}',
                PolikinlikAdi ='{item.PolikinlikAdi}',
                RandevuTarihi = {item.RandevuTarihi}',
                DoktorAdi =  '{item.DoktorAdi}' WHERE Id = {item.Id}";
            _context.Context.Execute(sql);
        }
    }
}