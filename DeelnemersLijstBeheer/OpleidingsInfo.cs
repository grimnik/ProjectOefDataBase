using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    public class OpleidingsInfo
    {
        public int Id { get; set; }
        public string Instelling { get; set; }
        public string Opleiding { get; set; }
        public string ContactPersoon { get; set; }
        public string OpleidingsPlaats { get; set; }
        public string RefOpleidingsPlaats { get; set; }
        public int OeNummer { get; set; }
        public int OpleidingsCode { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        public virtual List<Deelnemers> Deelnemers {get; set;}
        public virtual ICollection<Docenten> Docentens { get; set; }
        public virtual List<NietOpleidingsDagen> NietOpleidings { get; set; }
    }
}
