using CourseCatalogMini.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CourseCatalogMini.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly CourseCatalogDbContext db;

        public CoursesController(CourseCatalogDbContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var courses = db.Courses.ToList();

            return View(courses);
        }
    }
}