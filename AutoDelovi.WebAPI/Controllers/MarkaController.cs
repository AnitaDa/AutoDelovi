using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutoDelovi.Model;
using AutoDelovi.WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoDelovi.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : BaseController<MMarka, MarkaSearch, MarkaUpsertRequest, MarkaUpsertRequest>
    {
       public MarkaController(IBaseService<MMarka,MarkaSearch,MarkaUpsertRequest,MarkaUpsertRequest> baseService):base(baseService) { }
    }
}
