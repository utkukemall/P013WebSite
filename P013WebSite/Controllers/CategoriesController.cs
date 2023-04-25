using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;

namespace P013WebSite.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? id)
        {
            if (id is null) // Eğer adres çubuğundan id gönderilmişse 
            {
                return BadRequest(); // Ekrana geçersiz istek hatası ver id olmadığı zaman Bu sayfa çalışmıyorSorun devam ederse site sahibiyle iletişime geçin. uyarısı veriyor
            }
            var category = _context.Categories.Include(p=>p.Products).FirstOrDefault(c => c.Id == id); // id gönderilmişse db den o kategoriyi ara Include(p=>p.Products) yaparak foreach hatasından kurtulduk.
            if (category == null) // eğer kategori db de yoksa
            {
                return NotFound(); // geriye bulunamadı hatası döndür Bu localhost sayfası bulunamıyorŞu web adresi için web sayfası bulunamadı.... hatası veriyor.
            }
            return View(category); // kategori bulunduysa ekrana yolla 
        }
    }
}
