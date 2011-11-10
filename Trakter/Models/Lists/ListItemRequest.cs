using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter.Models.Lists
{
    public class ListItemRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Slug { get; set; }
        public List<dynamic> Items { get; set; }
    }
}
