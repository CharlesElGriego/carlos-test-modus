using Newtonsoft.Json;
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
        [JsonProperty(PropertyName = "feedId")]
        public int FeedId { get; set; }

        [Required]
        [JsonProperty(PropertyName = "userEmail")]
        public string UserEmail { get; set; }
    }
}