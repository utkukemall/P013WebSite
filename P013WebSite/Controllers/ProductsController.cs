﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P013WebSite.Data;

namespace P013WebSite.Controllers
{

    public class ProductsController : Controller
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> DetailAsync(int? id)
        {
            if (id is null) // Eğer adres çubuğundan id gönderilmişse 
            {
                return BadRequest(); // Ekrana geçersiz istek hatası ver id olmadığı zaman Bu sayfa çalışmıyorSorun devam ederse site sahibiyle iletişime geçin. uyarısı veriyor
            }
            var product = await _context.Products.Include("Category").FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }
    }
}
