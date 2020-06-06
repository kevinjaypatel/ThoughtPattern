using System;
using System.ComponentModel.DataAnnotations;

namespace ThoughtPattern.Models
{
    public class Thought
    {
        public int ID { get; set; }
        public string Description { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
    }
}

