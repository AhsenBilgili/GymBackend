using AutoMapper;
using DenemeForeignKey.Data;
using DenemeForeignKey.DTOs;
using DenemeForeignKey.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DenemeForeignKey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePageCardsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public HomePageCardsController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("gethomepagecards")]
        public async Task<ActionResult<IEnumerable<HomePageCardCreateDto>>> GetHomePageCards()
        {
            var homePageCards = await _context.HomePageCards.ToListAsync();

            var homePageCardsDtoList = _mapper.Map<List<HomePageCardCreateDto>>(homePageCards);

            return Ok(homePageCardsDtoList);
        }

        [HttpPost("createhomepagecard")]
        public async Task<ActionResult<HomePageCardCreateDto>> CreateHomePageCard(HomePageCardCreateDto homePageCardCreateDto)
        {
            var homePageCard = _mapper.Map<HomePageCard>(homePageCardCreateDto);

            _context.HomePageCards.Add(homePageCard);
            await _context.SaveChangesAsync();

            var createdHomePageCardDto = _mapper.Map<HomePageCardCreateDto>(homePageCard);

             return CreatedAtAction(nameof(GetHomePageCards), new { id = createdHomePageCardDto.HomePageCardId }, createdHomePageCardDto);
        }
    }
}
