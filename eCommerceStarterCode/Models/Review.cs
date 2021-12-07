using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("VideoGame")]
        public int VideoGameId { get; set; }
        public VideoGame VideoGame { get; set; }
        public int Rating { get; set; }
        public string ReviewChar { get; set; }
    }
}
