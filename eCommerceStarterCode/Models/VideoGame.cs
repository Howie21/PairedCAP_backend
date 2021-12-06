using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class VideoGame
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public string System { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }



    }
}
