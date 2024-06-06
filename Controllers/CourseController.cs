using AutoMapper;
using DenemeForeignKey.Data;
using DenemeForeignKey.DTOs;
using DenemeForeignKey.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DenemeForeignKey.Mapping;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly DataContext _context;
    private readonly IMapper _mapper; 

    public CourseController(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet("getcourses")]
    public async Task<ActionResult<IEnumerable<CourseCreateDto>>> GetAllCourses()
    {
        var courses = await _context.Courses.Include(c => c.CoursePrices).ToListAsync();

        var coursesDtoList = courses.Select(c => _mapper.Map<CourseCreateDto>(c)).ToList();

        return Ok(coursesDtoList);
    }

    [HttpPost("createcourse")]
    public async Task<ActionResult<CourseCreateDto>> CreateCourse(CourseCreateDto courseDto)
    {
        // Add validation if necessary

        var course = _mapper.Map<Course>(courseDto);

        _context.Courses.Add(course);
        await _context.SaveChangesAsync();

        var createdCourseDto = _mapper.Map<CourseCreateDto>(course);

        return CreatedAtAction(nameof(GetAllCourses), new { id = createdCourseDto.CourseId }, createdCourseDto);
    }

    [HttpGet("getcourse/{id}")]
    public async Task<ActionResult<CourseCreateDto>> GetCourseById(int id)
    {
        var course = await _context.Courses.Include(c => c.CoursePrices).FirstOrDefaultAsync(c => c.CourseId == id);

        if (course == null)
        {
            return NotFound();
        }

        var courseDto = _mapper.Map<CourseCreateDto>(course);

        return Ok(courseDto);
    }
}
