using System;
using System.Xml.Serialization;

namespace SharpTvDB.Models {

    [SerializableAttribute]
    public class SerieSearch {

        [XmlElementAttribute("seriesid")]
        public int Id { get; set; }

        [XmlElementAttribute("language")]
        public string Language { get; set; }

        [XmlElementAttribute("SeriesName")]
        public string Name { get; set; }

        [XmlElementAttribute("banner")]
        public string Banner { get; set; }

        public string Overview { get; set; }
        public DateTime? FirstAired { get; set; }

        [XmlElementAttribute("IMDB_ID")]
        public string ImdbID { get; set; }

        [XmlElementAttribute("zap2it_id")]
        public string Zap2ItID { get; set; }
    }
}