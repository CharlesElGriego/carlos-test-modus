﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataDB.Models
{
    public class Feed
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FeedName { get; set; }

    }
}