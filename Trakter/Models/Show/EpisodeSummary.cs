using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;
using Trakter.Models.Persons;
using Trakter.Models.User;

namespace Trakter.Models.Show
{
    public class EpisodeSummary
    {
        public TraktShow Show { get; set; }
        public TraktEpisode Episode { get; set; }
    }
}
