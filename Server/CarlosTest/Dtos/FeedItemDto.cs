using System;

namespace CarlosTest.Services
{
    public class FeedItemDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string ParentName { get; set; }
        public string Title { get; set; }
    }
}