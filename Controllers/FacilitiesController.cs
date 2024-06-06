using DenemeForeignKey.Data;
using DenemeForeignKey.DTOs;
using DenemeForeignKey.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace DenemeForeignKey.Controllers
{

    public class FacilitiesController : BaseApiController
    {
        private readonly DataContext _context;

        public FacilitiesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Facility>>> CreateFacility(FacilityCreateDto request)
        {
            var gymNameLower = request.Name.ToLower();

            // Check if a Facility with the same GymName already exists
            var existingFacility = await _context.Facilities
                .Include(f => f.SpecialCourses)
                .FirstOrDefaultAsync(f => f.GymName == gymNameLower);

            if (existingFacility != null)
            {
                // Facility with the same GymName already exists

                // Return the existing Facility ID
                return Ok(existingFacility.Id);
            }

            // Create a new Facility
            var newFacility = new Facility
            {
                GymName = gymNameLower,
                Address = request.Address,
                ImageUrl = request.ImageUrl, 
                Phone=request.Phone,
            };

            // Create SpecialCourses (if any)
            if (request.SpecialCourses != null && request.SpecialCourses.Any())
            {
                var specialCourses = new List<SpecialCourse>();

                foreach (var specialCourseDto in request.SpecialCourses)
                {
                    // Check if the SpecialCourse already exists by name
                    var existingSpecialCourse = await _context.SpecialCourses
                        .FirstOrDefaultAsync(sc => sc.SpecialCourseName.ToLower() == specialCourseDto.SpecialCourseName.ToLower());

                    if (existingSpecialCourse != null)
                    {
                        // If the SpecialCourse already exists, use the existing one
                        specialCourses.Add(existingSpecialCourse);
                    }
                    else
                    {
                        // If the SpecialCourse doesn't exist, create a new one
                        var newSpecialCourse = new SpecialCourse
                        {
                            SpecialCourseName = specialCourseDto.SpecialCourseName.ToLower(),
                            SpecialCourseDefinition = specialCourseDto.SpecialCourseDefinition,
                            SpecialCourseImgUrl = specialCourseDto.SpecialCourseImgUrl,
                            SpecialCourseCondition = specialCourseDto.SpecialCourseCondition
                        };
                        specialCourses.Add(newSpecialCourse);
                    }
                }

                newFacility.SpecialCourses = specialCourses;
            }


            _context.Facilities.Add(newFacility);
            await _context.SaveChangesAsync();

            return Ok(newFacility.Id);
        }

        [HttpGet("facilities")]
       
        public async Task<ActionResult<IEnumerable<FacilityWithSpecialCourses>>> GetFacilitiesWithSpecialCourses()
        {
            var facilities = await _context.Facilities
                .Include(f => f.SpecialCourses)
                .ToListAsync();

            if (facilities == null)
            {
                return NotFound();
            }

            var resultDtoList = facilities.Select(facility => new FacilityWithSpecialCourses
            {
                Id = facility.Id,
                GymName = facility.GymName,
                Address = facility.Address,
                ImageUrl =facility.ImageUrl,
                Phone= facility.Phone,
                SpecialCourses = facility.SpecialCourses.Select(sc => new SpecialCourseCreateDto
                {
                    Id = sc.Id,
                    SpecialCourseName = sc.SpecialCourseName,
                    SpecialCourseDefinition = sc.SpecialCourseDefinition,
                    SpecialCourseImgUrl = sc.SpecialCourseImgUrl,
                    SpecialCourseCondition = sc.SpecialCourseCondition
                }).ToList()
            }).ToList();

            return Ok(resultDtoList);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<FacilityWithSpecialCourses>> GetFacility(int id)
        {
            var facility = await _context.Facilities
                .Include(f => f.SpecialCourses) 
                .FirstOrDefaultAsync(f => f.Id == id);

            if (facility == null)
            {
                return NotFound();
            }

            var resultDto = new FacilityWithSpecialCourses
            {
                Id = facility.Id,
                GymName = facility.GymName,
                Address = facility.Address,
                ImageUrl = facility.ImageUrl,
                Phone = facility.Phone,

                SpecialCourses = facility.SpecialCourses.Select(sc => new SpecialCourseCreateDto
                {
                    Id = sc.Id,
                    SpecialCourseName = sc.SpecialCourseName,
                    SpecialCourseDefinition=sc.SpecialCourseDefinition,
                    SpecialCourseImgUrl = sc.SpecialCourseImgUrl,
                    SpecialCourseCondition = sc.SpecialCourseCondition
                }).ToList()
            };

            return Ok(resultDto);
        }
        [HttpPost("{Id}/add-trainer")]
        public async Task<ActionResult<int>> AddTrainerToFacility(int Id, TrainerCreateDto trainerDto)
        {
            // Find the Facility by ID
            var facility = await _context.Facilities
                .Include(f => f.Trainers)
                .FirstOrDefaultAsync(f => f.Id == Id);

            if (facility == null)
            {
                return NotFound("Facility not found");
            }
            if (facility.Trainers == null)
            {
                facility.Trainers = new List<Trainer>();
            }

            // Check if the Trainer already exists in the current facility by name
            var existingTrainerInFacility = facility.Trainers.FirstOrDefault(t => t.TrainerName.ToLower() == trainerDto.TrainerName.ToLower());

            if (existingTrainerInFacility != null)
            {
                // If the Trainer exists in the current facility, return an error
                return BadRequest("Trainer already added to the Facility");
            }

            // Check if the Trainer already exists globally by name
            var existingTrainer = await _context.Trainers
                .FirstOrDefaultAsync(t => t.TrainerName.ToLower() == trainerDto.TrainerName.ToLower());

            if (existingTrainer != null)
            {
                // If the Trainer exists but not in the current facility, return an error
                return BadRequest("Trainer already added in another Facility");
            }

            // If the Trainer doesn't exist at all, create a new one
            var newTrainer = new Trainer
            {
                TrainerName = trainerDto.TrainerName,
                TrainerImageUrl = trainerDto.TrainerImageUrl,
                TrainerDescription = trainerDto.TrainerDescription
                // Add other properties as needed
            };

            // Add DaySchedules if provided
            if (trainerDto.DaySchedules != null && trainerDto.DaySchedules.Any())
            {
                var daySchedules = new List<DaySchedule>();

                foreach (var dayScheduleDto in trainerDto.DaySchedules)
                {
                    var newDaySchedule = new DaySchedule
                    {
                        Day = dayScheduleDto.Day,
                        StartTime = dayScheduleDto.StartTime,
                        EndTime = dayScheduleDto.EndTime
                    };

                    daySchedules.Add(newDaySchedule);
                }

                newTrainer.DaySchedules = daySchedules;
            }

            // Add the new Trainer to the current facility
            facility.Trainers.Add(newTrainer);

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok("Trainer added to Facility successfully");
        }
        [HttpGet("all-trainers")]
        public async Task<ActionResult<IEnumerable<TrainerCreateDto>>> GetAllTrainers()
        {
            // Retrieve all facilities with trainers and day schedules
            var facilities = await _context.Facilities
                .Include(f => f.Trainers)
                    .ThenInclude(t => t.DaySchedules)
                .ToListAsync();

            // Flatten the list of trainers from all facilities
            var allTrainersDtoList = facilities.SelectMany(facility => facility.Trainers.Select(trainer => new TrainerCreateDto
            {
                Id = trainer.Id,
                TrainerName = trainer.TrainerName,
                TrainerImageUrl = trainer.TrainerImageUrl,
                TrainerDescription = trainer.TrainerDescription,

                DaySchedules = trainer.DaySchedules.Select(ds => new DayScheduleCreateDto
                {
                    Day = ds.Day,
                    StartTime = ds.StartTime,
                    EndTime = ds.EndTime
                }).ToList()
            })).ToList();

            return Ok(allTrainersDtoList);
        }
        [HttpGet("{specialCourseId}/trainers")]
        public async Task<ActionResult<IEnumerable<TrainerCreateDto>>> GetTrainersBySpecialCourseId(int specialCourseId)
        {
            // Find the Special Course by ID
            var specialCourse = await _context.SpecialCourses
                .Include(sc => sc.SpecialCourseTrainers)
                    .ThenInclude(sct => sct.Trainer)
                        .ThenInclude(t => t.DaySchedules)
                .FirstOrDefaultAsync(sc => sc.Id == specialCourseId);

            if (specialCourse == null)
            {
                return NotFound("Special Course not found");
            }

            // Retrieve trainers associated with the special course
            var trainersDtoList = specialCourse.SpecialCourseTrainers.Select(sct => sct.Trainer)
                .Select(trainer => new TrainerCreateDto
                {
                    Id = trainer.Id,
                    TrainerName = trainer.TrainerName,
                    TrainerImageUrl = trainer.TrainerImageUrl,
                    TrainerDescription = trainer.TrainerDescription,
                    DaySchedules = trainer.DaySchedules.Select(ds => new DayScheduleCreateDto
                    {
                        Day = ds.Day,
                        StartTime = ds.StartTime,
                        EndTime = ds.EndTime
                    }).ToList()
                }).ToList();

            return Ok(trainersDtoList);
        }

        [HttpPost("{facilityId}/add-special-course")]
        public async Task<ActionResult<int>> AddSpecialCourseToFacility(int facilityId, SpecialCourseCreateDto specialCourseDto)
        {
            // Find the Facility by ID
            var facility = await _context.Facilities
                .Include(f => f.SpecialCourses)
                .FirstOrDefaultAsync(f => f.Id == facilityId);

            if (facility == null)
            {
                return NotFound("Facility not found");
            }
            if (facility.SpecialCourses == null)
            {
                facility.SpecialCourses = new List<SpecialCourse>();
            }

            // Check if the SpecialCourse already exists by name
            var existingSpecialCourse = await _context.SpecialCourses
                .FirstOrDefaultAsync(sc => sc.SpecialCourseName.ToLower() == specialCourseDto.SpecialCourseName.ToLower());

            if (existingSpecialCourse != null)
            {
                // If the SpecialCourse already exists, use the existing one
                facility.SpecialCourses.Add(existingSpecialCourse);
            }
            else
            {
                // If the SpecialCourse doesn't exist, create a new one
                var newSpecialCourse = new SpecialCourse
                {
                    SpecialCourseName = specialCourseDto.SpecialCourseName.ToLower(),
                    SpecialCourseDefinition = specialCourseDto.SpecialCourseDefinition,
                    SpecialCourseImgUrl = specialCourseDto.SpecialCourseImgUrl,
                    SpecialCourseCondition = specialCourseDto.SpecialCourseCondition
                };

                facility.SpecialCourses.Add(newSpecialCourse);
            }

            // Save changes to the database
            await _context.SaveChangesAsync();

            return Ok("Special Course added to Facility successfully");
        }


    }

    public class FacilityWithSpecialCourses
    {
        public int Id { get; set; }
        public string GymName { get; set; }

        public string Address { get; set; }
        public string ImageUrl { get; set; }
        
        public string Phone { get; set; }
        public List<SpecialCourseCreateDto> SpecialCourses { get; set; }
    }


}
  