
namespace CourseCatalogMini.Services.DTOs.Courses;

public class CourseListDto
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string Teacher { get; set; } = "";

    public string Category { get; set; } = "";

    public int DurationHours { get; set; }

    public string Description { get; set; } = "";
}
