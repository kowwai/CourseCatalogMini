using Microsoft.AspNetCore.Mvc;
using CourseCatalogMini.Data.Entities;
using CourseCatalogMini.Services.Interfaces;
using CourseCatalogMini.Web.ViewModels.Courses;

namespace CourseCatalogMini.Web.Controllers;

public class CoursesController : Controller
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    public async Task<IActionResult> Index(
        string? search, string? category)
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
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Course course)
    {
        if (string.IsNullOrWhiteSpace(course.Name) ||
            course.Name.Length > 150)
        {
            ModelState.AddModelError(
                "Name", "Въведете име до 150 символа.");
        }

        if (string.IsNullOrWhiteSpace(course.Teacher) ||
            course.Teacher.Length > 100)
        {
            ModelState.AddModelError(
                "Teacher",
                "Въведете преподавател до 100 символа.");
        }

        if (string.IsNullOrWhiteSpace(course.Category) ||
            course.Category.Length > 50)
        {
            ModelState.AddModelError(
                "Category", "Изберете валидна категория.");
        }

        if (course.DurationHours <= 0)
        {
            ModelState.AddModelError(
                "DurationHours",
                "Продължителността трябва да е положителна.");
        }

        if (string.IsNullOrWhiteSpace(course.Description) ||
            course.Description.Length > 1000)
        {
            ModelState.AddModelError(
                "Description",
                "Въведете описание до 1000 символа.");
        }

        if (!ModelState.IsValid)
        {
            return View(course);
        }

        _courseService.AddCourse(course);

        return RedirectToAction("Index");
    }
}
