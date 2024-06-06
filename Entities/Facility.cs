using System.Text.Json.Serialization;

namespace DenemeForeignKey.Entities
{
    public class Facility

    {
        public int Id { get; set; }

        public String GymName { get; set; }

        public String ImageUrl { get; set; }

        public String Address { get; set; }

        public string Phone { get; set; }

        [JsonIgnore]
        public List<SpecialCourse> SpecialCourses { get; set;}

        [JsonIgnore]
        public List<Trainer> Trainers { get; set; }


    }
}
