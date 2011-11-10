using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models
{
    public class Ratings
    {
        public int Percentage { get; set; }
        public int Votes { get; set; }
        public int Loved { get; set; }
        public int Hated { get; set; }
    }
}
