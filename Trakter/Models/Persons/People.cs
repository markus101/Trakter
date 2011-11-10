using System.Collections.Generic;

namespace Trakter.Models.Persons
{
    public class People
    {
        public List<GenericPerson> Directors { get; set; }
        public List<Writer> Writers { get; set; }
        public List<GenericPerson> Producers { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
