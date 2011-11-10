using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models.Rate
{
    public class RateResult
    {
        public ResultStatusType Status { get; set; }
        public string Message { get; set; }
        public TraktType Type { get; set; }
        public RatingType Rating { get; set; }
        public bool Facebook { get; set; }
        public bool Twitter { get; set; }
        public bool Tumblr { get; set; }
    }
}
