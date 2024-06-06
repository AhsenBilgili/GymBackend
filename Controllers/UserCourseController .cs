using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization; // Ekledik
using DenemeForeignKey.Entities;
using DenemeForeignKey.Models;
using DenemeForeignKey.Data;

namespace DenemeForeignKey.Controllers
{
    [Authorize] // Authorize attribütünü ekledik
    [ApiController]
    [Route("[controller]")]
    public class UserCourseController : ControllerBase
    {
        private readonly DataContext _context;

        public UserCourseController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("course-details")]
        public async Task<IActionResult> GetUserCourseDetails()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Giriş yapmış kullanıcının ID'sini al


            // Kullanıcının kurs kayıtlarını, kurs bilgileriyle birlikte al
            var userCourses = await _context.UserCourseRegistrations
                .Include(uc => uc.Course)
                .Where(uc => uc.UserId == userId)
                .ToListAsync();

            // Kullanıcının üyelik tarihini al
            var membershipStartDate = userCourses.Min(uc => uc.RegistrationDate);

            // Kullanıcının abonelik süresini hesapla
            var subscriptionMonths = userCourses.Sum(uc => uc.SubscriptionMonths);

            // Şu anki tarihi al
            var currentDate = DateTime.Now;

            // Kullanıcının kursa devam edebileceği son tarih
            var endDate = membershipStartDate.AddMonths(subscriptionMonths);

            // Kullanıcının kursa devam edebileceği gün sayısını hesapla
            var remainingDays = (int)(endDate - currentDate).TotalDays;

            // Kullanıcının kurs bilgileri, üyelik tarihi, abonelik süresi ve kalan günleri döndür
            var userDetails = new
            {
                Courses = userCourses.Select(uc => uc.Course),
                MembershipStartDate = membershipStartDate,
                SubscriptionMonths = subscriptionMonths,
                RemainingDays = remainingDays
            };

            return Ok(userDetails);
        }

        [HttpPost("add-course")]
        public async Task<IActionResult> AddUserCourse(int courseId, int subscriptionMonths)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Giriş yapmış kullanıcının ID'sini al


            // Kullanıcıya kurs eklemek için UserCourseRegistration oluştur
            var userCourses = new UserCourseRegistration
            {
                UserId = userId,
                CourseId = courseId,
                RegistrationDate = DateTime.Now,
                SubscriptionMonths = subscriptionMonths
            };

            // Eklenen kursu kaydet
            _context.UserCourseRegistrations.Add(userCourses);
            await _context.SaveChangesAsync();

            return Ok("Course added successfully");
        }

    }
}
