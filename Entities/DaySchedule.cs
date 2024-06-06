namespace DenemeForeignKey.Entities
{
    public class DaySchedule
    {
        public int Id { get; set; }
        public DayOfWeek Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }

        public int TrainerId { get; set; }

        public Trainer Trainer { get; set;}

    }
}
