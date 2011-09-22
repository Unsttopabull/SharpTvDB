using System;
using System.Xml.Serialization;

namespace SharpTvDB.Models {

    [SerializableAttribute]
    public class Serie {

        public string ContentRating { get; set; }
        public DateTime FirstAired { get; set; }
        public string Language { get; set; }
        public string Network { get; set; }
        public string NetworkID { get; set; }
        public string Overview { get; set; }
        public double Rating { get; set; }
        public int RatingCount { get; set; }
        public int Runtime { get; set; }
        public int SeriesID { get; set; }
        public string SeriesName { get; set; }
        public string Status { get; set; }

        [XmlElementAttribute("id")]
        public int Id { get; set; }

        [XmlElementAttribute("Actors")]
        public string ActorsRaw;

        [XmlElementAttribute("Airs_DayOfWeek")]
        public string AirsDayOfWeek { get; set; }

        [XmlElementAttribute("Airs_Time")]
        public string AirsTime { get; set; }

        [XmlElementAttribute("Genre")]
        public string GenresRaw;

        [XmlElementAttribute("IMDB_ID")]
        public string ImdbID { get; set; }

        [XmlElementAttribute("added")]
        public string Added { get; set; }

        [XmlElementAttribute("addedBy")]
        public string AddedBy { get; set; }

        [XmlElementAttribute("banner")]
        public string Banner { get; set; }

        [XmlElementAttribute("fanart")]
        public string Fanart { get; set; }

        [XmlElementAttribute("lastupdated")]
        public long Lastupdated { get; set; }

        [XmlElementAttribute("poster")]
        public string Poster { get; set; }

        [XmlElementAttribute("zap2it_id")]
        public string Zap2ItID { get; set; }

        [XmlIgnore]
        public Season[] Seasons { get; set; }

        [XmlIgnore]
        public string[] Actors {
            get { return ActorsRaw.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries); }
            set { ActorsRaw = string.Join("|", value); }
        }

        [XmlIgnore]
        public string[] Genres {
            get { return GenresRaw.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries); }
            set { GenresRaw = string.Join("|", value); }
        }
    }
}