using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutoDelovi.Model;
namespace AutoDelovi.WebAPI
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Databases.Proizvod, eAutoDelovi.Model.MProizvod>();
            CreateMap<eAutoDelovi.Model.ProizvodUpsertRequest, Databases.Proizvod>().ReverseMap();
            CreateMap<Databases.Marka, eAutoDelovi.Model.MMarka>();
            CreateMap<eAutoDelovi.Model.MarkaUpsertRequest, Databases.Marka>().ReverseMap();
            CreateMap<Databases.Model, eAutoDelovi.Model.MModel>();
            CreateMap<eAutoDelovi.Model.ModelUpsertRequest, Databases.Model>().ReverseMap();
            CreateMap<eAutoDelovi.Model.NarudzbaUpsertRequest, Databases.Narudzba>().ReverseMap();
            CreateMap<Databases.VrstaProizvodum, eAutoDelovi.Model.MVrstaProizvoda>();
            CreateMap<eAutoDelovi.Model.VrstaProizvodaUpsertRequest, Databases.VrstaProizvodum>().ReverseMap();
            CreateMap<Databases.NarudzbaProizvod, eAutoDelovi.Model.MNarudzbaProizvod>();
            CreateMap<eAutoDelovi.Model.NarudzbaProizvodUpsert, Databases.NarudzbaProizvod>().ReverseMap();
        }
    }
}
