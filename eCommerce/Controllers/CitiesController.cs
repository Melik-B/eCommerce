using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        public IActionResult CitiesGet(int countryId)
        {
            var result = _cityService.List(countryId);
            var model = result.Data;
            return Json(model);
        }
    }
}
