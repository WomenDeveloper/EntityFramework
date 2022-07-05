using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


using WebAppDB.CustomValidators;

namespace WebAppDB.Models
{
    public class Urun
    {
        public int UrunID { get; set; }

        [StringLength(100)]
        [Column(TypeName ="varchar")]
        [Display(Name ="Ürün Adı")]
        [Required(ErrorMessage ="Boş geçemezsiniz...")]
        [EtSemboluOlmaz(ErrorMessage ="@ sembolu olmaz...")]
        public string UrunAdi { get; set; }

        [StringLength(15),Column(TypeName ="varchar")]
        [EtSemboluOlmaz(ErrorMessage = "@ sembolu olmaz...")]
        public string Renk { get; set; }

        [Column(TypeName ="money")]
        [Range(20,500,ErrorMessage ="20-500 arasında olmalı...")]
        public decimal Fiyat { get; set; }

        [StringLength(50), Column(TypeName = "varchar")]
        [Display(Name = "Ürün Resmi")]
        public string? UrunResmi { get; set; }

        public int KategoriID { get; set; }

        //Navigation Property...
        public Kategori? Kategori { get; set; } //1-M
        //public ICollection<Kategori> Kategoriler { get; set; }
    }
}
