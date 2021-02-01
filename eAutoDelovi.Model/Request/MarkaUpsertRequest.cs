using System;
using System.Collections.Generic;
using System.Text;

namespace eAutoDelovi.Model
{
    public class MarkaUpsertRequest
    {
        public int? MarkaId { get; set; } 
        public string Naziv { get; set; }
    }
}
