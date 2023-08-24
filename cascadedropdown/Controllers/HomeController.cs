using cascadedropdown.Data;
using cascadedropdown.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace cascadedropdown.Controllers
{
    public class HomeController : Controller
    {
      

        private readonly AppDBContext _context;

        

      
        public HomeController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult List()
        {
            List<Customer> customers = _context.Customers
                .Include(c=>c.Country)
                .Include(cy =>cy.City)
                .ToList();

            return View(customers);
        }

        private List<SelectListItem> GetCountries()
        {
            var lstCountries= new List<SelectListItem>();
            List<Country> countries = _context.Countries.ToList();

            lstCountries = countries.Select(ct => new SelectListItem()
            {
                Value = ct.Id.ToString(),
                Text = ct.CountryName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Country"
            };

            lstCountries.Insert(0, defItem);

            return lstCountries;
        }

        private List<SelectListItem> GetCities(int CountryId = 1)
        {

            List<SelectListItem> lstCities = _context.Cities
                .Where(c => c.CountryId == CountryId)
                .OrderBy(n => n.CityName)
                .Select(n =>
                 new SelectListItem
                 {
                     Value = n.Id.ToString(),
                     Text = n.CityName
                 }).ToList() ;

           
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select City"
            };

            lstCities.Insert(0, defItem);

            return lstCities;
        }

        [HttpGet]
        public IActionResult Create()
        {
            Customer Customer = new Customer();
            ViewBag.CountryId = GetCountries();
            ViewBag.CityId = GetCities();
            return View(Customer);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _context.Add(customer);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public JsonResult GetCitiesByCountry(int countryId)
        {
            List<SelectListItem> cities = GetCities(countryId);
            return Json(cities);
        }
    }
}