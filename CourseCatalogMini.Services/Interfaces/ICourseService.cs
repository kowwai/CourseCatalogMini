using CourseCatalogMini.Data.Entities;

namespace CourseCatalogMini.Services.Interfaces;

public interface ICourseService
{
    List<Course> GetAll();

    void AddCourse(Course course);
}
