using System;
using System.Collections.Generic;
using System.Text;

namespace eAutoDelovi.Model
{
    public class VrstaProizvodaUpsertRequest
    {
        public int VrstaProizvodaId { get; set; }
        public string Naziv { get; set; }
    }
}
