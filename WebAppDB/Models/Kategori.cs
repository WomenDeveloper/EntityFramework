using System.ComponentModel.DataAnnotations;

namespace WebAppDB.Models
{
    public class Kategori
    {
        //[Key]
        public int KategoriID { get; set; }
        public string KategoriAdi { get; set; }


        //Navigation Property
        public ICollection<Urun> Urunler { get; set; }
    }
}
