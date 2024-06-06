namespace DenemeForeignKey.DTOs
{
    public record struct TrainerCreateDto(
        int Id,
        string TrainerName,
        string TrainerImageUrl, 
        string TrainerDescription,
        List<DayScheduleCreateDto> DaySchedules
        
        );

}

