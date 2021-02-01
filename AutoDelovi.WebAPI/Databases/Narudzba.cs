using System;
using System.Collections.Generic;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            NarudzbaProizvods = new HashSet<NarudzbaProizvod>();
        }

        public int NarudzbaId { get; set; }
        public DateTime? Datum { get; set; }

        public virtual ICollection<NarudzbaProizvod> NarudzbaProizvods { get; set; }
    }
}
