using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
     public class Tijdregistraties 
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        
        public virtual Deelnemers Deelnemers { get; set; }
        public virtual OpleidingsInfo OpleidingsInfo { get; set; }
        public Tijdregistraties(Deelnemers deelnemers)
        {
            Deelnemers = deelnemers;
        }
        public Tijdregistraties()
        {

        }
    }
}
