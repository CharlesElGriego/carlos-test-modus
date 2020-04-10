using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarlosTest.Dtos
{
    public class UserFeedDto
    {
        [Required]
        public int FeedId { get; set; }

        [Required]
        public string UserEmail { get; set; }
    }
}