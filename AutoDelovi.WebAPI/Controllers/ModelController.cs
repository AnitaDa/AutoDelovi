using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoDelovi.WebAPI.Services;
using eAutoDelovi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDelovi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : BaseController<MModel, ModelSearch, ModelUpsertRequest, ModelUpsertRequest>
    {
        public ModelController(IBaseService<MModel, ModelSearch, ModelUpsertRequest, ModelUpsertRequest> baseService):base(baseService)
        {
        }
    }
}
