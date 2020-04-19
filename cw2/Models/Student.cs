using System;
using System.Xml.Serialization;

namespace cw2.Models
{ 
    [Serializable]
    public class Student
    {
        /* [XmlAttribute(attributeName : "student indexNumber")]
         public string indexNumber { get; set; }
         public string fname { get; set; }
         public string lname { get; set; } 
         public DateTime birthdate { get; set; }
         public string mothersName { get; set; }
       //  public Studies studies { get; set; }*/


        [XmlAttribute(attributeName: "email")]
        public string Email { get; set; }
        [XmlElement(elementName: "fname")]
        public string Imie { get; set; }

        //propfull + tabx2

        private string _nazwisko;
        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                if (value == null) throw new ArgumentException();
                _nazwisko = value;
            }
        }
    }
}
