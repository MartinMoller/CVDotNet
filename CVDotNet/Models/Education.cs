using System;
using System.Collections.Generic;

namespace CVDotNet.Models
{
    public partial class Education
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? From { get; set; }
        public string To { get; set; }
        public string Certificate { get; set; }
    }
}
