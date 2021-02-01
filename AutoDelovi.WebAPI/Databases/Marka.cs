using System;
using System.Collections.Generic;

#nullable disable

namespace AutoDelovi.WebAPI.Databases
{
    public partial class Marka
    {
        public Marka()
        {
            Models = new HashSet<Model>();
        }

        public int MarkaId { get; set; }
        public string Naziv { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
