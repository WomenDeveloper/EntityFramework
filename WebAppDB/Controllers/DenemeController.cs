using Microsoft.AspNetCore.Mvc;

using WebAppDB.Data;
namespace WebAppDB.Controllers
{
    public class DenemeController : Controller
    {
        UrunDB _db;
        public DenemeController(UrunDB db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Urunler.ToList());
        }
    }
}
