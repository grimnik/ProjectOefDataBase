using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    class Tijdregistraties 
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int OpleidingId { get; set; }
        public int DeelnemerId { get; set; }
        public virtual Deelnemers Deelnemers { get; set; }
        public virtual OpleidingsInfo OpleidingsInfo { get; set; }
    }
}
