using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    public class Docenten 
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Bedrijf { get; set; }
        
        public virtual ICollection<OpleidingsInfo> OpleidingsInfo { get; set; }
    }
}
