using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using SharpTvDB.Models;

namespace SharpTvDB {
    public enum SerieOption {
        JustSerie,
        WithEpisodes
    }

    public class TheTvDB : IDisposable {

        public string ApiKey { private get; set; }
        private readonly WebClient _webCl;
        public string Language { get; set; }

        public TheTvDB(string apiKey, string language) {
            ApiKey = apiKey;
            Language = language;
            _webCl = new WebClient { Encoding = Encoding.UTF8, Proxy = null };
        }

        #region Episodes
        private Episode GetEpisode(string url) {
            byte[] data = _webCl.DownloadData(url);
            return SerializeEpisode(data);
        }

        public Episode GetEpisode(int serieId, int absoluteEpisodeNumber) {
            return GetEpisode(string.Format(ApiUrl.GetSeriesAbsoluteUrl, ApiKey, serieId, absoluteEpisodeNumber, Language ));
        }

        public Episode GetEpisode(int episodeId) {
            return GetEpisode(string.Format(ApiUrl.GetEpisodeUrl, ApiKey, episodeId, Language));
        }

        public Episode GetEpisode(int serieId, int seasonNumber, int episodeNumer) {
            return GetEpisode(string.Format(ApiUrl.GetSeriesDefaultUrl, ApiKey, serieId, seasonNumber, episodeNumer, Language));
        }
        #endregion

        #region Series
        public Serie GetSerie(int tvdbID, SerieOption options = SerieOption.JustSerie) {
            byte[] data = _webCl.DownloadData(string.Format(
                (options == SerieOption.JustSerie) ? ApiUrl.GetSeriesUrl : ApiUrl.GetSeriesFullUrl,
                    ApiKey, tvdbID, Language)
            );

            return SerializeSerie(data);
        }

        public SerieSearch[] SearchSeries(string title) {
            byte[] data = _webCl.DownloadData(string.Format(ApiUrl.SearchSeriesUrl, title));

            return ParseXML(data);
        }
        #endregion

        #region Serializing
        public static Episode SerializeEpisode(byte[] xml) {
            XmlSerializer xs = new XmlSerializer(typeof(Episode));

            Data obj;
            using (MemoryStream ms = new MemoryStream(xml)) {
                obj = (Data)xs.Deserialize(ms);
            }

            return obj.Episodes[0];
        }

        public static Serie SerializeSerie(byte[] xml) {
            XmlSerializer xs = new XmlSerializer(typeof(Data));

            Data obj;
            using (MemoryStream ms = new MemoryStream(xml)) {
                obj = (Data)xs.Deserialize(ms);
            }

            var serie = obj.Series[0];
            if (obj.Episodes.Length != 0) {
                serie.Seasons = obj.Episodes.GroupBy(ep => ep.SeasonNumber)
                    .Select(grouped =>
                            new Season {
                                Number = (int)grouped.Key,
                                Episodes = grouped.ToArray()
                            }).ToArray();
            }

            return serie;
        }
        #endregion

        #region Parsing
        private static SerieSearch[] ParseXML(byte[] data) {
            using (var ms = new MemoryStream(data)) {
                XDocument xdoc = XDocument.Load(XmlReader.Create(ms));

                return xdoc.Descendants("Series").Select(
                    xe => new SerieSearch {
                        Id = int.Parse(xe.Element("seriesid").Value),
                        Name = xe.Element("SeriesName").Value,
                        Language = xe.Element("language").Value,
                        Zap2ItID = TryParse("zap2it_id", xe),
                        ImdbID = TryParse("IMDB_ID", xe),
                        Banner = TryParse("banner", xe),
                        Overview = TryParse("Overview", xe),
                        FirstAired = TryParseDt("FirstAired", xe)
                    }).ToArray();
            }
        }

        private static string TryParse(string attrName, XElement xe) {
            var xElement = xe.Element(attrName);
            return xElement != null ? xElement.Value : null;
        }

        private static DateTime? TryParseDt(string attrName, XElement xe) {
            DateTime dt = new DateTime();
            var xElement = xe.Element(attrName);
            if (xElement != null)
                DateTime.TryParse(xElement.Value, out dt);
            return dt;
        }
        #endregion

        public void Dispose() {
            if (_webCl != null) {
                _webCl.Dispose();
            }
        }
    }
}
