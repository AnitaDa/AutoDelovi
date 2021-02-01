using System;
using System.Collections.Generic;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class Proizvod
    {
        public Proizvod()
        {
            NarudzbaProizvods = new HashSet<NarudzbaProizvod>();
        }

        public int ProizvodId { get; set; }
        public string Sifra { get; set; }
        public int Kolicina { get; set; }
        public int ModelId { get; set; }
        public int VrstaProizvodaId { get; set; }

        public virtual Model Model { get; set; }
        public virtual VrstaProizvodum VrstaProizvoda { get; set; }
        public virtual ICollection<NarudzbaProizvod> NarudzbaProizvods { get; set; }
    }
}
