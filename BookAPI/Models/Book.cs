﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Isbn { get; set; }
        public string Title { get; set; }
        public DateTime DatePublished { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public int MyProperty { get; set; }
    }
}