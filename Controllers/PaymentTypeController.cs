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
    public class PaymentTypeController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public PaymentTypeController(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("getpaymenttypes")]
        public async Task<ActionResult<IEnumerable<PaymentTypeCreateDto>>> GetAllPaymentTypes()
        {
            var paymentTypes = await _context.PaymentTypes.ToListAsync();

            var paymentTypesDtoList = _mapper.Map<List<PaymentTypeCreateDto>>(paymentTypes);

            return Ok(paymentTypesDtoList);
        }

        [HttpPost("createpaymenttype")]
        public async Task<ActionResult<PaymentTypeCreateDto>> CreatePaymentType(PaymentTypeCreateDto paymentTypeDto)
        {
            var paymentType = _mapper.Map<PaymentType>(paymentTypeDto);

            _context.PaymentTypes.Add(paymentType);
            await _context.SaveChangesAsync();

            var createdPaymentTypeDto = _mapper.Map<PaymentTypeCreateDto>(paymentType);

            return CreatedAtAction(nameof(GetAllPaymentTypes), new { id = createdPaymentTypeDto.PaymentTypeId }, createdPaymentTypeDto);
        }

        [HttpGet("getpaymenttype/{id}")]
        public async Task<ActionResult<PaymentTypeCreateDto>> GetPaymentTypeById(int id)
        {
            var paymentType = await _context.PaymentTypes
                .FirstOrDefaultAsync(pt => pt.PaymentTypeId == id);

            if (paymentType == null)
            {
                return NotFound();
            }

            var paymentTypeDto = _mapper.Map<PaymentTypeCreateDto>(paymentType);

            return Ok(paymentTypeDto);
        }
    }
}
