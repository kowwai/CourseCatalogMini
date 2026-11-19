using CourseCatalogMini.Data.Entities;
using CourseCatalogMini.Services.DTOs.Courses;

namespace CourseCatalogMini.Services.Interfaces;

public interface ICourseService
{
    Task<List<CourseListDto>> GetAll(
        string? search,
        string? category);

    void AddCourse(Course course);
}
