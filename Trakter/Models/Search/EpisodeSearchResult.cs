using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models.Search
{
    public class EpisodeSearchResult
    {
        public TraktShow Show { get; set; }
        public TraktEpisode Episode { get; set; }
    }
}
