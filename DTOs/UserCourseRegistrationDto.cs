namespace DenemeForeignKey.DTOs
{
    public class UserCourseRegistrationDto
    {
        
   
            public int CourseId { get; set; }
            public string CourseName { get; set; }
            public string CourseDescription { get; set; }
            public DateTime RegistrationDate { get; set; }
            public int SubscriptionMonths { get; set; }
        }
    }

