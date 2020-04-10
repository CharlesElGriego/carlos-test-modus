using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataDB.Models
{
    public class UserFeed
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int FeedId { get; set; }

        public virtual Feed Feed { get; set; }
        public virtual User User { get; set; }

    }
}