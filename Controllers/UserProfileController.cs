using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace DenemeForeignKey.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserProfileController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetProfile()
        {
            // Kullanıcının talep ettiği kimliği al
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Eğer bir kullanıcı kimliği bulunamazsa, NotFound dön
            if (userId == null)
            {
                return NotFound();
            }

            // Kullanıcı kimliğine göre kullanıcıyı bul
            var user = await _userManager.FindByIdAsync(userId);

            // Eğer kullanıcı bulunamazsa, NotFound dön
            if (user == null)
            {
                return NotFound();
            }

            // Kullanıcı adı ve e-posta adresini alarak JSON olarak dön
            return Ok(new
            {
                UserName = user.UserName,
                Email = user.Email
            });
        }
    }
}
