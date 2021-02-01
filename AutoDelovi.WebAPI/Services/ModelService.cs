using eAutoDelovi.Model;
using AutoDelovi.WebAPI.Databases;
using AutoDelovi.WebAPI.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoDelovi.WebAPI.Services.Model
{
    public class ModelService:BaseServices<MModel,ModelSearch,ModelUpsertRequest,ModelUpsertRequest,Databases.Model>
    {
        private readonly AutoDeloviiContext _context;
        private readonly IMapper _mapper;
        public ModelService(AutoDeloviiContext context, IMapper mapper) : base(context, mapper) {
            _context = context;
            _mapper = mapper;
        }
        public override List<MModel> Get(ModelSearch search)
        {
            var query = _context.Models.AsQueryable();
            if (search.Naziv != null)
            {
                query = query.Where(x => x.Naziv.Equals(search.Naziv));
            }
            var list = query.Select(x=>new MModel { 
            Naziv=x.Naziv,
            NazivMarke=x.Marka.Naziv,
            ModelId=x.ModelId
            }).ToList();
            return _mapper.Map<List<MModel>>(list);
        }
    }
}
