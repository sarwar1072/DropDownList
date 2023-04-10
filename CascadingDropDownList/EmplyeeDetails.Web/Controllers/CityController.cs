﻿using EmplyeeDetails.Web.Data;
using EmplyeeDetails.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EmplyeeDetails.Web.Controllers
{
    public class CityController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CityController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    
        public IActionResult Index()
        {
            var cities = _appDbContext.city.ToList();
            return View(cities);
        }

        [HttpGet]
        public IActionResult Create()
        {
            City City = new City();
            ViewBag.Countries = GetCountries();
            return View(City);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(City City)
        {

            _appDbContext.Add(City);
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            City City = _appDbContext.city
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(City);
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            City City = _appDbContext.city
              .Where(c => c.Id == Id).FirstOrDefault();

            ViewBag.Countries = GetCountries();

            return View(City);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(City City)
        {
            _appDbContext.Attach(City);
            _appDbContext.Entry(City).State = EntityState.Modified;
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int Id)
        {
            City City = _appDbContext.city
              .Where(c => c.Id == Id).FirstOrDefault();

            return View(City);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Delete(City City)
        {
            _appDbContext.Attach(City);
            _appDbContext.Entry(City).State = EntityState.Deleted;
            _appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



        public List<SelectListItem> GetCountries()
        {
            var lstCountries = new List<SelectListItem>(); 
            var countries=_appDbContext.country.ToList();
            lstCountries = countries.Select(ct => new SelectListItem(){
                Value= ct.Id.ToString(), 
                Text=ct.Name
            }).ToList();
            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "----Select Country----"
            };
            lstCountries.Insert(0, defItem);
            return lstCountries;
        }
    }
}
