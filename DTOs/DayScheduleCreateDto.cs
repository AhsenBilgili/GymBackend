namespace DenemeForeignKey.DTOs
{
    public record struct DayScheduleCreateDto(
        DayOfWeek Day ,
        string StartTime ,
        string EndTime
        );
    
}
