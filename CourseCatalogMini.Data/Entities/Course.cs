namespace CourseCatalogMini.Data.Entities
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; } = null!;

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public int DurationHours { get; set; }

        public string Description { get; set; } = "";
    }
}