using System;
using System.Collections.Generic;

namespace CVDotNet.Models
{
    public partial class Work
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
