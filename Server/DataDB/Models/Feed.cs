using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataDB.Models
{
    public class Feed
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required]
        [MaxLength(50)]
        public string FeedName { get; set; }

        public virtual bool IsSubscribed { get; set; }
        public virtual ICollection<UserFeed> UserFeeds { get; set; }
        public virtual ICollection<FeedItem> FeedItems { get; set; }
    }
}