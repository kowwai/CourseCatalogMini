using Microsoft.AspNetCore.Mvc;
using CourseCatalogMini.Services.DTOs.Courses;
using CourseCatalogMini.Services.Interfaces;
using CourseCatalogMini.Web.ViewModels.Courses;

namespace CourseCatalogMini.Web.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index(
            string? search,
            string? category)
        {
            var model = new CoursesIndexViewModel
            {
                Courses = await _courseService.GetAll(
                    search, category),

                Search = search,
                Category = category
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CourseCreateDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CourseCreateDto model)
        {
            if (string.IsNullOrWhiteSpace(model.Name) ||
                model.Name.Length > 150)
            {
                ModelState.AddModelError(
                    "Name",
                    "Въведете име до 150 символа.");
            }

            if (string.IsNullOrWhiteSpace(model.Teacher) ||
                model.Teacher.Length > 100)
            {
                ModelState.AddModelError(
                    "Teacher",
                    "Въведете преподавател до 100 символа.");
            }

            if (string.IsNullOrWhiteSpace(model.Category) ||
                model.Category.Length > 50)
            {
                ModelState.AddModelError(
                    "Category",
                    "Изберете категория до 50 символа.");
            }

            if (model.DurationHours <= 0)
            {
                ModelState.AddModelError(
                    "DurationHours",
                    "Продължителността трябва да е положителна.");
            }

            if (string.IsNullOrWhiteSpace(model.Description) ||
                model.Description.Length > 1000)
            {
                ModelState.AddModelError(
                    "Description",
                    "Въведете описание до 1000 символа.");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _courseService.AddCourse(model);

            return RedirectToAction("Index");
        }
    }
}