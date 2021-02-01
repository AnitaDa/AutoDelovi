using eAutoDelovi.Model;
using AutoDelovi.WebAPI.Databases;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDelovi.WebAPI.Services;

namespace AutoDelovi.WebAPI.Services.Proizvod
{
    public class ProizvodService: BaseServices<MProizvod,ProizvodSearch,ProizvodUpsertRequest,ProizvodUpsertRequest,Databases.Proizvod>
    {
        private readonly AutoDeloviiContext _context;
        private readonly IMapper _mapper;

        public ProizvodService(AutoDeloviiContext context, IMapper mapper):base(context,mapper){
            _context = context;
            _mapper = mapper;
        }
        public override List<MProizvod> Get(ProizvodSearch search)
        {
            var query = _context.Proizvods.AsQueryable();
            if (search.ModelId != 0)
            {
                query = query.Where(x => x.ModelId == search.ModelId);
            }
            if (search.Sifra != null)
            {
                query = query.Where(x => x.Sifra == search.Sifra);
            }
            if (search.VrstaProizvodaId != 0)
            {
                query = query.Where(x => x.VrstaProizvodaId == search.VrstaProizvodaId);
            }
            var list = query.Select(x => new MProizvod {
            ProizvodId=x.ProizvodId,
            Sifra=x.Sifra,
            Kolicina=x.Kolicina,
            Naziv=x.Model.Naziv,
            Vrsta=x.VrstaProizvoda.Naziv,
            ModelId=x.ModelId,
            VrstaProizvodaId=x.VrstaProizvodaId
            }).ToList();
            return _mapper.Map<List<MProizvod>>(list);
        }
    }
}
