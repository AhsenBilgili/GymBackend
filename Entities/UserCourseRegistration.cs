
using Microsoft.AspNetCore.Identity;
using Windows.System;

namespace DenemeForeignKey.Entities
{
    public class UserCourseRegistration
    {
        public int Id { get; set; }

        public string UserId { get; set; } 
        public IdentityUser User { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime RegistrationDate { get; set; }

        public int SubscriptionMonths { get; set; }
    }
}
