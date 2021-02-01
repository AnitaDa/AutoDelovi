using System;
using System.Collections.Generic;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class NarudzbaProizvod
    {
        public int NarudzbaId { get; set; }
        public int ProizvodId { get; set; }

        public virtual Narudzba Narudzba { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
