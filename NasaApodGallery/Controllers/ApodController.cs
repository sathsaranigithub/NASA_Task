using Microsoft.AspNetCore.Mvc;
using NasaApodGallery.Data;
using NasaApodGallery.Services;

namespace NasaApodGallery.Controllers
{
    public class ApodController : Controller
    {
        private readonly NasaApodService _nasaService;
        private readonly ApodRepository _repository;

        public ApodController(NasaApodService nasaService, ApodRepository repository)
        {
            _nasaService = nasaService;
            _repository = repository;
        }

        public async Task<IActionResult> FetchAndSave(string startDate, string endDate)
        {
            var apods = await _nasaService.GetApodRange(startDate, endDate);

            foreach (var apod in apods)
            {
                _repository.SaveApod(apod);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
