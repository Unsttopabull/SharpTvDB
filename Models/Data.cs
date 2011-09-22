using System;
using System.Xml.Serialization;

namespace SharpTvDB.Models {
    [Serializable]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Data {

        [XmlElementAttribute("Series")]
        public Serie[] Series { get; set; }

        [XmlElementAttribute("Episode", IsNullable = true)]
        public Episode[] Episodes { get; set; }
    }
}