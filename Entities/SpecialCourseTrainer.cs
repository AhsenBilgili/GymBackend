namespace DenemeForeignKey.Entities
{
    public class SpecialCourseTrainer
    {
        public int Id { get; set; }

        public int SpecialCourseId { get; set; }
        public SpecialCourse SpecialCourse { get; set; }

        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }
    }
}
