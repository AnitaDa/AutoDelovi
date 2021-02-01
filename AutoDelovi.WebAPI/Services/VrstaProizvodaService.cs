using eAutoDelovi.Model;
using AutoDelovi.WebAPI.Databases;
using AutoDelovi.WebAPI.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI.Services.VrstaProizvoda
{
    public class VrstaProizvodaService:BaseServices<MVrstaProizvoda, VrstaProizvodaSearch, VrstaProizvodaUpsertRequest, VrstaProizvodaUpsertRequest,Databases.VrstaProizvodum>
    {
        private readonly AutoDeloviiContext _context;
        private readonly IMapper _mapper;
        public VrstaProizvodaService(AutoDeloviiContext context, IMapper mapper) : base(context, mapper) {
            _context = context;
            _mapper = mapper;
        }
        public override List<MVrstaProizvoda> Get(VrstaProizvodaSearch search)
        {
            var query = _context.VrstaProizvoda.AsQueryable();
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv == search.Naziv);
            }
            var list = query.Select(x => new MVrstaProizvoda { 
            Naziv=x.Naziv,
            VrstaProizvodaId=x.VrstaProizvodaId
            }).ToList();
            return _mapper.Map<List<MVrstaProizvoda>>(list);
        }
    }
}
