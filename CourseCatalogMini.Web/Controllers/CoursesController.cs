using CourseCatalogMini.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using CourseCatalogMini.Data.Entities;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Course course)
        {
            if (string.IsNullOrWhiteSpace(course.Name))
            {
                ModelState.AddModelError("Name", "Въведете име на курса.");
            }

            if (string.IsNullOrWhiteSpace(course.Teacher))
            {
                ModelState.AddModelError("Teacher", "Въведете преподавател.");
            }

            if (string.IsNullOrWhiteSpace(course.Category))
            {
                ModelState.AddModelError("Category", "Изберете категория.");
            }

            if (course.DurationHours <= 0)
            {
                ModelState.AddModelError(
                    "DurationHours",
                    "Продължителността трябва да е повече от 0 часа.");
            }

            if (string.IsNullOrWhiteSpace(course.Description))
            {
                ModelState.AddModelError("Description", "Въведете описание.");
            }

            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(course);
        }
    }
}