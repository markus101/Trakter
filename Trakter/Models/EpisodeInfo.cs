using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models
{
    public class EpisodeInfo
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int TvdbId { get; set; }
        public string ImdbId { get; set; }
        public int Season { get; set; }
        public int Episode { get; set; }
    }
}
