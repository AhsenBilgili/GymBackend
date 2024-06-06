namespace DenemeForeignKey.DTOs
{
    public record struct FacilityCreateDto(
        string Name,
        string Address,
        string ImageUrl,
        string Phone,
        List<SpecialCourseCreateDto> SpecialCourses,
        List<TrainerCreateDto>Trainers);

 
    
}
