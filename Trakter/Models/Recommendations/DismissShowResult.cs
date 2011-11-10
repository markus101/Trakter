using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models.Recommendations
{
    public class DismissSHowResult
    {
        public ResultStatusType Status { get; set; }
        public string Message { get; set; }
        public DismissedMovie Show { get; set; }
    }
}
