﻿using System.ComponentModel.DataAnnotations;

namespace stroy2.Models
{
    public class Feedbacks
    {
        public Guid Id { get; set; }
        public string? Client { get; set; }
        public string? WorkName { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Period { get; set; }

        public string? Comment { get; set; }

        public string? Contacts { get; set; }
        public bool Confirm { get; set; }
    }
}
