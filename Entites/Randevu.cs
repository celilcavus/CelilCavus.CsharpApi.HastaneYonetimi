using System;

namespace CelilCavus.Entites
{
  public class Randevu
  {
    public int Id { get; set; }
    public string RandevuNo { get; set; }   
    public string HastaAdi { get; set; }
    public string PolikinlikAdi { get; set; }
    public DateTime RandevuTarihi { get; set; }
    public string DoktorAdi { get; set; }
  }
}