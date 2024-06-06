namespace DenemeForeignKey.DTOs
{
    public record struct CourseCreateDto
    (
        int CourseId ,

        string CourseImage ,

        string CourseName ,

        string CourseDescription ,

        string CourseParticipantCondition,

        List<CoursePriceCreateDto> CoursePrices
);
    
}
