using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    class Deelnemers 
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string WoonPlaats { get; set; }
        public int BadgeNummer { get; set; }
        public virtual OpleidingsInfo OpleidingsInfo { get; set; }
       public virtual List<Tijdregistraties> Tijdregistraties { get; set; }
    }
}
