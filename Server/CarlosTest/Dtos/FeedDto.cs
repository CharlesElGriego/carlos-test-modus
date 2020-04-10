using System.Collections.Generic;

namespace CarlosTest.Services
{
    public class FeedDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FeedItemDto> items { get; set; }
    }
}