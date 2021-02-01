using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDelovi.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDelovi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TModel,TSerach,TUpdate,TInsert> : ControllerBase
    {
        private readonly IBaseService<TModel, TSerach, TUpdate, TInsert> _service;
        public BaseController(IBaseService<TModel, TSerach, TUpdate, TInsert> service)
        {
            _service = service;
        }
        [HttpGet]
        public List<TModel> Get([FromQuery]TSerach search)
        {
            return _service.Get(search);
        }
        [HttpGet("{Id}")]
        public TModel GetById(int Id)
        {
            return _service.GetById(Id);
        }
        [HttpPost]
        public TModel Insert(TInsert insert)
        {
            return _service.Insert(insert);
        }
        [HttpPut]
        public TModel Update(int Id, TUpdate update)
        {
            return _service.Update(Id, update);
        }
        [HttpDelete("{Id}")]
        public bool Delete(int Id)
        {
            return _service.Delete(Id);
        }
    }
}
