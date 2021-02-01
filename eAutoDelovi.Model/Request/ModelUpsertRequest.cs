using System;
using System.Collections.Generic;
using System.Text;

namespace eAutoDelovi.Model
{
    public class ModelUpsertRequest
    {
        public int ModelId { get; set; }
        public string Naziv { get; set; }
        public int? MarkaId { get; set; }
    }
}
