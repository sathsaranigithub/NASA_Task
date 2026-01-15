using Microsoft.AspNetCore.Mvc;
using NasaApodGallery.Data;
using NasaApodGallery.Models;
using System.Diagnostics;

namespace NasaApodGallery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApodRepository _repository;

        public HomeController(ILogger<HomeController> logger, ApodRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var apods = _repository.GetAll();
            return View(apods);
        }

        public IActionResult Privacy()
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
