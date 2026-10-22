using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseCatalogMini.Data.Enums;

public enum CourseCategory
{
    [Display(Name = "Програмиране")]
    Programming = 1,

    [Display(Name = "Чужди езици")]
    Languages = 2,

    [Display(Name = "Дизайн")]
    Design = 3,

    [Display(Name = "Бизнес")]
    Business = 4,

    [Display(Name = "Други")]
    Other = 5
}
