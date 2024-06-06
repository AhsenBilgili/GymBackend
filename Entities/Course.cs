using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DenemeForeignKey.Entities
{
    public class Course
    {
        public int CourseId { get; set; }

        public string CourseImage { get; set; }
   
        public string CourseName { get; set; }
     
        public string CourseDescription { get; set; }
    
        public string CourseParticipantCondition { get; set; }
        [JsonIgnore]

        public List<CoursePrice> CoursePrices { get; set; }

    }
}
