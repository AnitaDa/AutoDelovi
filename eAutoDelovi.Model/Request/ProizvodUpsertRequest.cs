using System;
using System.Collections.Generic;
using System.Text;

namespace eAutoDelovi.Model
{
    public class ProizvodUpsertRequest
    {
        public int ProizvodId { get; set; }
        public string Sifra { get; set; }
        public int Kolicina { get; set; }
        public int ModelId { get; set; }
        public int VrstaProizvodaId { get; set; }
    }
}
