namespace DenemeForeignKey.DTOs
{
    public record struct PaymentTypeCreateDto
    (
        int PaymentTypeId,
        string PaymentTypeName,
        List<CoursePriceCreateDto> CoursePrices


        );
}
