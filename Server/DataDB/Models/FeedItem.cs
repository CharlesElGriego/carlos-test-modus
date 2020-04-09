using System.ComponentModel.DataAnnotations;

namespace DataDB.Models
{
    public class FeedItem
    {
        public int Id { get; set; }

        [Required]
        public int FeedId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Content { get; set; }

       
    }
}