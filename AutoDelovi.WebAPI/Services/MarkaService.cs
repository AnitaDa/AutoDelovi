
using AutoDelovi.WebAPI.Databases;
using AutoMapper;
using eAutoDelovi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI.Services.Marka
{
    public class MarkaService : BaseServices<MMarka, MarkaSearch, MarkaUpsertRequest, MarkaUpsertRequest, Databases.Marka>
    {
        private readonly AutoDeloviiContext _context;
        private readonly IMapper _mapper;
        public MarkaService(AutoDeloviiContext context, IMapper mapper) : base(context, mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public override List<MMarka> Get(MarkaSearch search)
        {
            var query = _context.Markas.AsQueryable();
            if (search.Naziv!=null)
            {
                query = query.Where(x => x.Naziv.Equals(search.Naziv));
            }
            var list = query.ToList();
            return _mapper.Map<List<MMarka>>(list);
        }
    }
}
