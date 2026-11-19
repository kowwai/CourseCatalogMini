using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CourseCatalogMini.Data;
using CourseCatalogMini.Data.Entities;
using CourseCatalogMini.Services.Interfaces;


namespace CourseCatalogMini.Services.Services
{
    public class CourseService : ICourseService
    {
        private readonly CourseCatalogDbContext _context;

        public CourseService(CourseCatalogDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }
}
