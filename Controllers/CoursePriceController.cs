using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DenemeForeignKey.DTOs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DenemeForeignKey.Entities;
using DenemeForeignKey.Data;

namespace DenemeForeignKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursePriceController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CoursePriceController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getcourseprices")]
        public async Task<ActionResult<IEnumerable<CoursePriceCreateDto>>> GetAllCoursePrices()
        {
            var coursePrices = await _context.CoursePrices.ToListAsync();

            var coursePricesDtoList = _mapper.Map<List<CoursePriceCreateDto>>(coursePrices);

            return Ok(coursePricesDtoList);
        }

        [HttpPost("createcourseprice")]
        public async Task<ActionResult<CoursePriceCreateDto>> CreateCoursePrice(CoursePriceCreateDto coursePriceDto)
        {
            // Kullanıcıdan alınan CourseId ve PaymentTypeId ile ilgili entity'leri çek
            var course = await _context.Courses.FindAsync(coursePriceDto.CourseId);
            var paymentType = await _context.PaymentTypes.FindAsync(coursePriceDto.PaymentTypeId);

            if (course == null || paymentType == null)
            {
                return BadRequest("Invalid CourseId or PaymentTypeId");
            }

            var coursePrice = _mapper.Map<CoursePrice>(coursePriceDto);
            coursePrice.Courses = course;
            coursePrice.PaymentTypes = paymentType;

            _context.CoursePrices.Add(coursePrice);
            await _context.SaveChangesAsync();

            var createdCoursePriceDto = _mapper.Map<CoursePriceCreateDto>(coursePrice);

            return CreatedAtAction(nameof(GetAllCoursePrices), new { id = createdCoursePriceDto.CoursePriceId }, createdCoursePriceDto);
        }


        [HttpGet("getcourseprice/{id}")]
        public async Task<ActionResult<CoursePriceCreateDto>> GetCoursePriceById(int id)
        {
            var coursePrice = await _context.CoursePrices
                .FirstOrDefaultAsync(cp => cp.CoursePriceId == id);

            if (coursePrice == null)
            {
                return NotFound();
            }

            var coursePriceDto = _mapper.Map<CoursePriceCreateDto>(coursePrice);

            return Ok(coursePriceDto);
        }
    }
}
