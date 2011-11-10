using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models.Lists
{
    public class ListItemResult
    {
        public ResultStatusType Status { get; set; }
        public int Inserted { get; set; }
        public int Already_Exist { get; set; }
        public int Skipped { get; set; }
        public List<dynamic> Skipped_Array { get; set; }
        public string Message { get; set; }
    }
}
