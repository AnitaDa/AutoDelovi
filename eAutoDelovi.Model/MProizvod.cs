using System;

namespace eAutoDelovi.Model
{
    public class MProizvod
    {
        public int ProizvodId { get; set; }
        public string Sifra { get; set; }
        public int Kolicina { get; set; }
        public string Naziv { get; set; }
        public string Vrsta { get; set; }
        public int ModelId { get; set; }
        public int VrstaProizvodaId { get; set; }
    }
}
