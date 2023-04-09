using CascadingDropDownList.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CascadingDropDownList.Web.Controllers
{
    public class DropDownController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public DropDownController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public JsonResult Country()
        {
            var crt = _appDbContext.country.ToList();
            return new JsonResult(crt);
        }
        public JsonResult State( int id)
        {
            var crt = _appDbContext.states.Where(x=>x.country.Id==id).ToList();
            return new JsonResult(crt);
        }
        public JsonResult City(int id)
        {
            var crt=_appDbContext.city.Where(x=>x.state.Id==id).ToList();
            return new JsonResult(crt);
        }
        public IActionResult Cascading()
        {
            return View();
        }
    }
}
