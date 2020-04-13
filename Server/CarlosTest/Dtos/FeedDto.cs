using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarlosTest.Dtos
{
    public class FeedDto
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "image")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "isSubscribed")]
        public bool IsSubscribed { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "items")]
        public List<FeedItemDto> Items { get; set; }

       
    }
}