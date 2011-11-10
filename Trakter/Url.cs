using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter
{
    internal static class Url
    {
        //Calendar
        internal static string CalendarPremieres
        {
            get { return "http://api.trakt.tv/calendar/premieres.json/"; }
        }
        internal static string CalendarShows
        {
            get { return "http://api.trakt.tv/calendar/shows.json/"; }
        }

        //Genres
        internal static string GenresMovies
        {
            get { return "http://api.trakt.tv/genres/movies.json/"; }
        }
        internal static string GenresShows
        {
            get { return "http://api.trakt.tv/genres/shows.json/"; }
        }
        
        //Lists
        internal static string ListsAdd
        {
            get { return "http://api.trakt.tv/lists/add/"; }
        }
        internal static string ListsDelete
        {
            get { return "http://api.trakt.tv/lists/delete/"; }
        }
        internal static string ListsUpdate
        {
            get { return "http://api.trakt.tv/lists/update/"; }
        }
        internal static string ListsItemsAdd
        {
            get { return "http://api.trakt.tv/lists/items/add/"; }
        }
        internal static string ListsItemsDelete
        {
            get { return "http://api.trakt.tv/lists/items/delete/"; }
        }

        //Movie
        internal static string MovieCancelWatching
        {
            get { return "http://api.trakt.tv/movie/cancelwatching/"; }
        }
        internal static string MovieScrobble
        {
            get { return "http://api.trakt.tv/movie/scrobble/"; }
        }
        internal static string MovieSeen
        {
            get { return "http://api.trakt.tv/movie/seen/"; }
        }
        internal static string MovieLibrary
        {
            get { return "http://api.trakt.tv/movie/library/"; }
        }
        internal static string MovieShouts
        {
            get { return "http://api.trakt.tv/movie/shouts/"; }
        }
        internal static string MovieSummary
        {
            get { return "http://api.trakt.tv/movie/summary/"; }
        }
        internal static string MovieUnlibrary
        {
            get { return "http://api.trakt.tv/movie/unlibrary/"; }
        }
        internal static string MovieUnseen
        {
            get { return "http://api.trakt.tv/movie/unseen/"; }
        }
        internal static string MovieUnwatchlist
        {
            get { return "http://api.trakt.tv/movie/unwatchlist/"; }
        }
        internal static string MovieWatching
        {
            get { return "http://api.trakt.tv/movie/watching/"; }
        }
        internal static string MovieWatchingNow
        {
            get { return "http://api.trakt.tv/movie/watchingnow/"; }
        }
        internal static string MovieWatchlist
        {
            get { return "http://api.trakt.tv/movie/watchlist/"; }
        }

        //Movies
        internal static string MoviesTrending
        {
            get { return "http://api.trakt.tv/movies/trending.json/"; }
        }

        //Rate
        internal static string RateEpisode
        {
            get { return "http://api.trakt.tv/rate/episode/"; }
        }
        internal static string RateMovie
        {
            get { return "http://api.trakt.tv/rate/movie/"; }
        }
        internal static string RateShow
        {
            get { return "http://api.trakt.tv/rate/show/"; }
        }

        //Recommendations
        internal static string RecommendationsMovies
        {
            get { return "http://api.trakt.tv/recommendations/movies/"; }
        }
        internal static string RecommendationsMoviesDismiss
        {
            get { return "http://api.trakt.tv/recommendations/movies/dismiss/"; }
        }
        internal static string RecommendationsShows
        {
            get { return "http://api.trakt.tv/recommendations/shows/"; }
        }
        internal static string RecommendationsShowsDismiss
        {
            get { return "http://api.trakt.tv/recommendations/shows/dismiss/"; }
        }

        //Search
        internal static string SearchEpisodes
        {
            get { return "http://api.trakt.tv/search/episodes.json/"; }
        }
        internal static string SearchMovies
        {
            get { return "http://api.trakt.tv/search/movies.json/"; }
        }
        internal static string SearchPeople
        {
            get { return "http://api.trakt.tv/search/people.json/"; }
        }
        internal static string SearchShows
        {
            get { return "http://api.trakt.tv/search/shows.json/"; }
        }
        internal static string SearchUsers
        {
            get { return "http://api.trakt.tv/search/users.json/"; }
        }

        //Search
        internal static string ShoutEpisode
        {
            get { return "http://api.trakt.tv/shout/episode/"; }
        }
        internal static string ShoutMovie
        {
            get { return "http://api.trakt.tv/shout/movie/"; }
        }
        internal static string ShoutShow
        {
            get { return "http://api.trakt.tv/shout/show/"; }
        }

        //Show
        internal static string ShowCancelWatching
        {
            get { return "http://api.trakt.tv/show/cancelwatching/"; }
        }
        internal static string ShowEpisodeLibrary
        {
            get { return "http://api.trakt.tv/show/episode/library/"; }
        }
        internal static string ShowEpisodeSeen
        {
            get { return "http://api.trakt.tv/show/episode/seen/"; }
        }
        internal static string ShowEpisodeShouts
        {
            get { return "http://api.trakt.tv/show/episode/shouts.json/"; }
        }
        internal static string ShowEpisodeSummary
        {
            get { return "http://api.trakt.tv/show/episode/summary.json/"; }
        }
        internal static string ShowEpisodeUnlibrary
        {
            get { return "http://api.trakt.tv/show/episode/unlibrary/"; }
        }
        internal static string ShowEpisodeUnseen
        {
            get { return "http://api.trakt.tv/show/episode/unseen/"; }
        }
        internal static string ShowEpisodeUnwatchlist
        {
            get { return "http://api.trakt.tv/show/episode/unwatchlist/"; }
        }
        internal static string ShowEpisodeWatchingNow
        {
            get { return "http://api.trakt.tv/show/episode/watchingnow.json/"; }
        }
        internal static string ShowEpisodeWatchlist
        {
            get { return "http://api.trakt.tv/show/episode/watchlist/"; }
        }
        internal static string ShowLibrary
        {
            get { return "http://api.trakt.tv/show/library/"; }
        }
        internal static string ShowRelated
        {
            get { return "http://api.trakt.tv/show/related.json/"; }
        }
        internal static string ShowScrobble
        {
            get { return "http://api.trakt.tv/show/scrobble/"; }
        }
        internal static string ShowSeason
        {
            get { return "http://api.trakt.tv/show/season.json/"; }
        }
        internal static string ShowSeasonLibrary
        {
            get { return "http://api.trakt.tv/show/season/library/"; }
        }
        internal static string ShowSeasonSeen
        {
            get { return "http://api.trakt.tv/show/season/seen/"; }
        }
        internal static string ShowSeasons
        {
            get { return "http://api.trakt.tv/show/seasons.json/"; }
        }
        internal static string ShowSeen
        {
            get { return "http://api.trakt.tv/show/seen/"; }
        }
        internal static string ShowShouts
        {
            get { return "http://api.trakt.tv/show/shouts.json/"; }
        }
        internal static string ShowSummary
        {
            get { return "http://api.trakt.tv/show/summary.json/"; }
        }
        internal static string ShowUnlibrary
        {
            get { return "http://api.trakt.tv/show/unlibrary/"; }
        }
        internal static string ShowUnwatchlist
        {
            get { return "http://api.trakt.tv/show/unwatchlist/"; }
        }
        internal static string ShowWatching
        {
            get { return "http://api.trakt.tv/show/watching/"; }
        }
        internal static string ShowWatchingNow
        {
            get { return "http://api.trakt.tv/show/watchingnow.json/"; }
        }
        internal static string ShowWatchlist
        {
            get { return "http://api.trakt.tv/show/watchlist/"; }
        }
        
    }
}
