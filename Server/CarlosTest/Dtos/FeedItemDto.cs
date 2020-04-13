using Newtonsoft.Json;
using System;

namespace CarlosTest.Services
{
    public class FeedItemDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "parentName")]
        public string ParentName { get; set; }

        [JsonProperty(PropertyName = "parentImage")]
        public string ParentImage { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}