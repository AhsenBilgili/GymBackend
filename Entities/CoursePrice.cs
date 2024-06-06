namespace DenemeForeignKey.Entities
{
    public class CoursePrice
    {
        public int CoursePriceId { get; set; }

        public int CourseId { get; set; }

        public Course Courses { get; set; }

        public int PaymentTypeId { get; set; }

        public PaymentType PaymentTypes { get; set; }

        public string CourseLong { get; set; }

        public int Price { get; set; }

    }
}
