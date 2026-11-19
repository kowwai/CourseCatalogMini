using CourseCatalogMini.Services.DTOs.Courses;

namespace CourseCatalogMini.Web.ViewModels.Courses;

public class CoursesIndexViewModel
{
    public List<CourseListDto> Courses { get; set; }
        = new();

    public string? Search { get; set; }

    public string? Category { get; set; }
}
