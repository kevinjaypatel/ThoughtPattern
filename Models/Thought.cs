using System;
using System.ComponentModel.DataAnnotations;

namespace ThoughtPattern.Models
{
    public class Thought
    {
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        [Display(Name = "Release Date"), DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
    }
}

