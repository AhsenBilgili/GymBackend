using System.Text.Json.Serialization;

namespace DenemeForeignKey.Entities
{
    public class SpecialCourse
    {
        public int Id { get; set; }

        public string SpecialCourseName { get; set; }

        public string SpecialCourseDefinition { get; set; }

        public string SpecialCourseImgUrl { get; set; }

        public string SpecialCourseCondition { get; set; }
        [JsonIgnore]

        public List<SpecialCourseTrainer> SpecialCourseTrainers { get; set; }

        [JsonIgnore]

        public List<Facility> Facilities{ get; set; }


    }
}
