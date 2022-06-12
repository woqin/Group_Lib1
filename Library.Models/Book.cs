﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string BarCode { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public DateTime PublishDate { get; set; }
        public int BookCategory { get; set; }
        public double UnitPrice { get; set; }
        public string BookImage { get; set; }
        public int BookCount { get; set; }
        public int Remainder { get; set; }
        public string BookPosition { get; set; }
        public DateTime RegTime { get; set; }

        //扩展属性

    }
}
