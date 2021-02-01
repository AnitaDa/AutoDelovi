using eAutoDelovi.Model;
using AutoDelovi.WebAPI.Databases;
using AutoDelovi.WebAPI.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI.Services.NarudzbaProizvod
{
    public class NarudzbaProizvodService : BaseServices<MNarudzbaProizvod, NarudzbaProizvodSearch, NarudzbaProizvodUpsert, NarudzbaProizvodUpsert, Databases.NarudzbaProizvod>
    {
        private readonly AutoDeloviiContext _context;
        private readonly IMapper _mapper;
        public NarudzbaProizvodService(AutoDeloviiContext context, IMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public override List<MNarudzbaProizvod> Get(NarudzbaProizvodSearch search)
        {         
            var query = _context.NarudzbaProizvods.AsQueryable();
            if (search.NazivProizvoda != null)
            {
                query = query.Where(x => x.Proizvod.Sifra.Equals(search.NazivProizvoda));
            }
            var list = query.Select(x => new MNarudzbaProizvod
            {
               NazivProizvoda=x.Proizvod.VrstaProizvoda.Naziv+" "+x.Proizvod.Model.Naziv+" "+x.Proizvod.Sifra
            }).ToList();
            return _mapper.Map<List<MNarudzbaProizvod>>(list);
        }
    }
    }

