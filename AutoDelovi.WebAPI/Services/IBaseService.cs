using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI.Services
{
   public interface IBaseService<TModel,TSearch,TUpdate, TInsert>
    {
        List<TModel> Get(TSearch search);
        TModel GetById(int Id);
        TModel Insert(TInsert insert);
        bool Delete(int Id);
        TModel Update(int Id, TUpdate update); 
    }
}
