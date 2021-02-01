using System;
using System.Collections.Generic;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class VrstaProizvodum
    {
        public VrstaProizvodum()
        {
            Proizvods = new HashSet<Proizvod>();
        }

        public int VrstaProizvodaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Proizvod> Proizvods { get; set; }
    }
}
