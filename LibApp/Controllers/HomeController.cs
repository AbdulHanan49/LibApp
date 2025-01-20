using System.Diagnostics;
using LibApp.Data;
using LibApp.Models;
using LibApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly CartService _cartService;
        public HomeController(ILogger<HomeController> logger, AppDbContext context, CartService cartService)
        {
            _logger = logger;
            _context = context;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }

        public IActionResult SearchBooks(string query)
        {
            var results = string.IsNullOrEmpty(query)
                ? new List<Book>()
                : _context.Books
                    .Where(b => b.Title.Contains(query) || b.Author.Contains(query))
                    .ToList();

            return View("Search", results);
        }

        public async Task<IActionResult> OurBooks()
        {
            var books = await _context.Books.ToListAsync();
            return View(books);
        }


        //[Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
