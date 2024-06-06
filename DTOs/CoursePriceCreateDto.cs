using DenemeForeignKey.DTOs;

namespace DenemeForeignKey.DTOs
{
    public record struct CoursePriceCreateDto
    (   int CoursePriceId,
        string CourseLong ,
        decimal Price,
        int CourseId,
        int PaymentTypeId);
       
}
 
