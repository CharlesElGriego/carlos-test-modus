using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarlosTest.Services
{
    public class FeedDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<FeedItemDto> Items { get; set; }
    }
}