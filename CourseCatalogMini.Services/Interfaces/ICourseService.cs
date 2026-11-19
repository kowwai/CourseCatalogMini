using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseCatalogMini.Data.Entities;

public interface ICourseService
{
    List<Course> GetAll();

    void AddCourse(Course course);
}
