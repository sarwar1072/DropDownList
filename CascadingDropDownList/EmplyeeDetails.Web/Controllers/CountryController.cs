using EmplyeeDetails.Web.Data;
using EmplyeeDetails.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmplyeeDetails.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly AppDbContext _context; 
        public CountryController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Country> list = _context.country.ToList();
            return View(list);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var country= new Country(); 
            return View(country);  
        }
        [HttpPost]
        public IActionResult Create(Country country)
        {
            _context.Add(country);
            _context.SaveChanges(); 
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var country = GetCountry(id);
            return View(country);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var country = GetCountry(id);
            return View(country);
        }
        [HttpPost]
        public IActionResult Edit(Country country)
        {
            _context.Attach(country);
            _context.Entry(country).State=EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public Country GetCountry(int id)
        {
            var country = _context.country.Where(c => c.Id ==id).FirstOrDefault();
            return country;
        }
        [HttpGet]
        public IActionResult Delete(int Id)
        {
            Country country = GetCountry(Id);
            return View(country);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(Country country)
        {

            _context.Attach(country);
            _context.Entry(country).State = EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
