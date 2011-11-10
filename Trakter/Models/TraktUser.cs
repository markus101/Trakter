using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.JsonConverters;
using Trakter.Models.User;

namespace Trakter.Models
{
    public class TraktUser
    {
        public string Username { get; set; }
	    public bool Protected { get; set; }

        [JsonProperty(PropertyName = "full_name")]
	    public string FullName { get; set; }

	    public GenderType? Gender { get; set; }

        //Trakt seems to allow this to be a nullable field, so we must respect that
	    public int? Age { get; set; }
	    public string Location { get; set; }
        public string About { get; set; }

        [JsonConverter(typeof(EpochDateTimeConverter))]
	    public DateTime Joined { get; set; }
	    public string Avatar { get; set; }
	    public string Url { get; set; }

        public int Plays { get; set; }
    }
}
