using AutoDelovi.WebAPI.Databases;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI.Services
{
    public class BaseServices<TModel, TSearch, TUpdate, TInsert,TDatabases> : IBaseService<TModel, TSearch, TUpdate, TInsert>where TDatabases:class
    {
        private readonly AutoDeloviiContext _context;
        private readonly IMapper _mapper;

        public BaseServices(AutoDeloviiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public bool Delete(int Id)
        {
            if (Id != 0)
            {
                var entity = _context.Set<TDatabases>().Find(Id);
                if (entity != null)
                {
                    _context.Set<TDatabases>().Remove(entity);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            return false;
        }

        virtual public List<TModel> Get(TSearch search)
        {
            var listObj = _context.Set<TDatabases>().ToList();
            return _mapper.Map<List<TModel>>(listObj);
        }

        public TModel GetById(int Id)
        {
            var obj= _context.Set<TDatabases>().Find(Id);
            return _mapper.Map<TModel>(obj);
        }

        public virtual TModel Insert(TInsert insert)
        {
            var entity = _mapper.Map<TDatabases>(insert);
            _context.Set<TDatabases>().Add(entity);
            _context.SaveChanges();
            return _mapper.Map<TModel>(entity);
        }

        public TModel Update(int Id, TUpdate update)
        {
            var searchObj = _context.Set<TDatabases>().Find(Id);  
                _context.Set<TDatabases>().Attach(searchObj);
                _context.Set<TDatabases>().Update(searchObj);
                _mapper.Map(update,searchObj);
                _context.SaveChanges();
                return _mapper.Map<TModel>(searchObj);           
        }
    }
}
