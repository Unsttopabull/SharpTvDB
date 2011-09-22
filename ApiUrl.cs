namespace SharpTvDB {
    public static class ApiUrl {
         public const string SearchSeriesUrl = "http://thetvdb.com/api/GetSeries.php?seriesname={0}"; //{0} - series name
         public const string GetSeriesUrl = "http://www.thetvdb.com/api/{0}/series/{1}/{2}.xml"; //{0} - api key, {1} - seriesId, {2} - language
         public const string GetSeriesFullUrl = "http://www.thetvdb.com/api/{0}/series/{1}/all/{2}.xml"; //{0} - api key, {1} - seriesId, {2} - language
         public const string GetSeriesDvDUrl = "http://www.thetvdb.com/api/{0}/series/{1}/dvd/{2}/{3}/{4}.xml"; //{0} - api key, {1} - seriesId, {2} - season num, {3} - episode num, {4} - language
         public const string GetSeriesDefaultUrl = "http://www.thetvdb.com/api/{0}/series/{1}/default/{2}/{3}/{4}.xml"; //{0} - api key, {1} - seriesId, {2} - season num, {3} - episode num, {4} - language
         public const string GetSeriesAbsoluteUrl = "http://www.thetvdb.com/api/{0}/series/{1}/absolute/{2}/{3}.xml"; //{0} - api key, {1} - seriesId, {2} - absolute num, {3} - language

         public const string GetEpisodeUrl = "http://www.thetvdb.com/api/{0}/episodes/{1}/{2}.xml"; //{0} - api key, {1} - episodeId, {2} - language

    }
}