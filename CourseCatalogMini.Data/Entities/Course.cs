using System.ComponentModel.DataAnnotations;
using CourseCatalogMini.Data.Enums;

namespace CourseCatalogMini.Data.Entities;

public class Course
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Въведете име на курса.")]
    [StringLength(100, ErrorMessage = "Името може да е до 100 символа.")]
    [Display(Name = "Име на курса")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Въведете преподавател.")]
    [StringLength(100, ErrorMessage = "Името може да е до 100 символа.")]
    [Display(Name = "Преподавател")]
    public string Teacher { get; set; } = string.Empty;

    [EnumDataType(
        typeof(CourseCategory),
        ErrorMessage = "Изберете валидна категория.")]
    [Display(Name = "Категория")]
    public CourseCategory Category { get; set; } = CourseCategory.Programming;

    [Range(1, int.MaxValue,
        ErrorMessage = "Продължителността трябва да е положително число.")]
    [Display(Name = "Продължителност в часове")]
    public int DurationHours { get; set; }

    [Required(ErrorMessage = "Въведете описание.")]
    [StringLength(2000,
        ErrorMessage = "Описанието може да е до 2000 символа.")]
    [DataType(DataType.MultilineText)]
    [Display(Name = "Описание")]
    public string Description { get; set; } = string.Empty;
}