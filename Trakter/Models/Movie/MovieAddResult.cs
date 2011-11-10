using System.Collections.Generic;

namespace Trakter.Models.Movie
{
    public class MovieAddResult
    {
        public ResultStatusType Status { get; set; }
        public int Inserted { get; set; }
        public int Already_Exist { get; set; }
        public List<TraktMovieSearch> Already_Exist_Movies { get; set; }
        public int Skipped { get; set; }
        public List<TraktMovieSearch> Skipped_Movies { get; set; }
    }
}
