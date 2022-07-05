using Microsoft.EntityFrameworkCore;

using WebAppDB.Models;

namespace WebAppDB.Data
{
    public class UrunDB:DbContext
    {
        public UrunDB(DbContextOptions<UrunDB> opt):base(opt)
        {

        }

        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Data Initialization
            modelBuilder.Entity<Kategori>().HasData(
                new Kategori { KategoriID=1, KategoriAdi="Kırtasiye" },
                new Kategori { KategoriID=2, KategoriAdi="Hobi" },
                new Kategori { KategoriID=3, KategoriAdi="Elektronik" }
                );

            modelBuilder.Entity<Urun>().HasData(
                new Urun { UrunID=1, UrunAdi="Defter", KategoriID=1, Renk="Sarı", Fiyat=44, UrunResmi="defter.jpg" },
                new Urun { UrunID=2, UrunAdi="Satranç", KategoriID=2, Renk="Siyah", Fiyat=120, UrunResmi="satranc.jpg" },
                new Urun { UrunID=3, UrunAdi="Silgi", KategoriID=1, Renk="Beyaz", Fiyat=10, UrunResmi="silgi.jpg" }
                );
        }
    }
}
