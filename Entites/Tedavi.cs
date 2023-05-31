using System;

namespace CelilCavus.Entites
{
    public class Tedavi
    {
        public int Id { get; set; }
        public string TedaviNo { get; set; }
        public string HastaneAdi { get; set; }
        public string DoktorAdi { get; set; }
        public string HastaAdi { get; set; }
        public string PolikinlikAdi { get; set; }
        public DateTime TedaviTarihi { get; set; }
        public decimal Ucret { get; set; }
    }
}