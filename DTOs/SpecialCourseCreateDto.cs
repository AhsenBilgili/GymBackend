namespace DenemeForeignKey.DTOs
{
    public record struct SpecialCourseCreateDto(
        int Id,
        string SpecialCourseName, 
        string SpecialCourseDefinition,
        string SpecialCourseImgUrl,
        string SpecialCourseCondition,
        List<TrainerCreateDto> Trainers
        );


}
