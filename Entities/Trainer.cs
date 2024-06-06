using System.Text.Json.Serialization;

namespace DenemeForeignKey.Entities
{
    public class Trainer
    {
        public int Id { get; set; }

        public string TrainerName { get; set; }

        public string TrainerImageUrl { get; set; }

        public string TrainerDescription { get; set; }

        public int  FacilityId { get; set; }

        public Facility Facilities { get; set; }
        [JsonIgnore]
        public List<SpecialCourseTrainer> SpecialCourseTrainers { get; set; }

        [JsonIgnore]

        public List<DaySchedule> DaySchedules { get; set; }

   
    }
}
