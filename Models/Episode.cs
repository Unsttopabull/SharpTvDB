using System;
using System.Xml.Serialization;

namespace SharpTvDB.Models {
    [Serializable]
    public class Episode {

        public string Director { get; set; }

        public string EpImgFlag { get; set; } //int
        public string EpisodeName { get; set; }
        public string EpisodeNumber { get; set; }
        public DateTime? FirstAired { get; set; }
        public string Language { get; set; }
        public string Overview { get; set; }
        public string ProductionCode { get; set; } //int
        public string Rating { get; set; } //double
        public int? RatingCount { get; set; } //int
        public int? SeasonNumber { get; set; } //int
        public string Writer { get; set; }

        [XmlIgnore]
        public string[] GuestStars {
            get { return GuestStarsRaw.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries); }
            set { GuestStarsRaw = string.Join("|", value); }
        }

        [XmlElementAttribute("GuestStars")]
        public string GuestStarsRaw { get; set; }

        [XmlElementAttribute("id")]
        public int ID { get; set; } //int

        [XmlElementAttribute("Combined_episodenumber")]
        public double? CombinedEpisodenumber { get; set; }

        [XmlElementAttribute("Combined_season")]
        public int CombinedSeason { get; set; } //int

        [XmlElementAttribute("IMDB_ID")]
        public string ImdbID { get; set; }

        [XmlElementAttribute("filename")]
        public string Filename { get; set; }

        [XmlElementAttribute("lastupdated")]
        public string LastUpdated { get; set; }

        [XmlElementAttribute("seasonid")]
        public int SeasonID { get; set; } //int

        [XmlElementAttribute("seriesid")]
        public int SeriesID { get; set; } //int
    }
}