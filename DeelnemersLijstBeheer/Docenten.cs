﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeelnemersLijstBeheer
{
    class Docenten 
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Bedrijf { get; set; }
        
        public virtual OpleidingsInfo OpleidingsInfo { get; set; }
    }
}
