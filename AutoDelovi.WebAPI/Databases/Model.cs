using System;
using System.Collections.Generic;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class Model
    {
        public Model()
        {
            Proizvods = new HashSet<Proizvod>();
        }

        public int ModelId { get; set; }
        public string Naziv { get; set; }
        public int? MarkaId { get; set; }

        public virtual Marka Marka { get; set; }
        public virtual ICollection<Proizvod> Proizvods { get; set; }
    }
}
