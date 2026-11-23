using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCatalogMini.Services.DTOs.Courses
{
    public class CourseCreateDto
    {
        public string Name { get; set; } = "";

        public string Teacher { get; set; } = "";

        public string Category { get; set; } = "";

        public int DurationHours { get; set; }

        public string Description { get; set; } = "";
    }
}
