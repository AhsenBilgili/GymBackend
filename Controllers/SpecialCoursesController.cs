using DenemeForeignKey.Data;
using DenemeForeignKey.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SpecialCoursesController : ControllerBase
{
    private readonly DataContext _context;

    public SpecialCoursesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("getcourses")]
    public async Task<ActionResult<IEnumerable<SpecialCourseCreateDto>>> GetAllSpecialCourses()
    {
        var specialCourses = await _context.SpecialCourses.ToListAsync();

        var specialCoursesDtoList = specialCourses.Select(sc => new SpecialCourseCreateDto
        {
            Id = sc.Id,
            SpecialCourseName = sc.SpecialCourseName,
            SpecialCourseDefinition = sc.SpecialCourseDefinition,
            SpecialCourseImgUrl = sc.SpecialCourseImgUrl,
            SpecialCourseCondition = sc.SpecialCourseCondition
        }).ToList();

        return Ok(specialCoursesDtoList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SpecialCourseCreateDto>> GetSpecialCourseById(int id)
    {
        var specialCourse = await _context.SpecialCourses.FindAsync(id);

        if (specialCourse == null)
        {
            return NotFound();
        }

        var specialCourseDto = new SpecialCourseCreateDto
        {
            Id = specialCourse.Id,
            SpecialCourseName = specialCourse.SpecialCourseName,
            SpecialCourseDefinition = specialCourse.SpecialCourseDefinition,
            SpecialCourseImgUrl = specialCourse.SpecialCourseImgUrl,
            SpecialCourseCondition = specialCourse.SpecialCourseCondition
        };

        return Ok(specialCourseDto);
    }
}
