using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DenemeForeignKey.Entities
{
    public class HomePageCard
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HomePageCardId { get; set; }
        public string HomePageCardContent { get; set; }
       
        public string HomePageCardImage { get; set; }
    }
}
