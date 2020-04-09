using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDB.Models
{
    public class UserFeed
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [Required]
        public int UserId { get; set; }
        [Index(IsUnique = true)]
        [Required]
        public int FeedId { get; set; }

       
    }
}