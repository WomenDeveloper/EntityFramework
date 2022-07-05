using Microsoft.AspNetCore.Mvc;

using WebAppDB.Data;
using Microsoft.EntityFrameworkCore;
using WebAppDB.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebAppDB.Controllers
{
    public class UrunController : Controller
    {
        private readonly UrunDB _db;

        public UrunController(UrunDB db)
        {
            _db = db;

           // _db.Database.EnsureDeleted();
           // _db.Database.EnsureCreated();
        }

        public IActionResult Index()
        {
            
            return View(_db.Urunler.Include("Kategori").ToList());
        }

        public IActionResult Ekle()
        {
            ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Urun urun,IFormFile dosya)
        {
            //Buralar degisecek...

            if (ModelState.IsValid)
            {

                Guid guid = Guid.NewGuid();

                string strDosyaAdi = guid + dosya.FileName;

                FileStream fs = new FileStream("wwwroot/resimler/" + strDosyaAdi, FileMode.Create);
                dosya.CopyTo(fs);
                fs.Close();


                urun.UrunResmi = strDosyaAdi;
                _db.Urunler.Add(urun);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Kategoriler = new SelectList(_db.Kategoriler.ToList(), "KategoriID", "KategoriAdi");
            return View();
        }
    }
}
