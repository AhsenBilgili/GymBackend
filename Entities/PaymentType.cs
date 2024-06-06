using System.Text.Json.Serialization;

namespace DenemeForeignKey.Entities
{
    public class PaymentType
    {   public int PaymentTypeId {  get; set; }
        public string PaymentTypeName { get; set; }

        [JsonIgnore]

        public List<CoursePrice> CoursePrices { get; set; }

    }
}
