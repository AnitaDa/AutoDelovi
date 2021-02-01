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
    public class VrstaProizvodaController : BaseController<MVrstaProizvoda, VrstaProizvodaSearch, VrstaProizvodaUpsertRequest, VrstaProizvodaUpsertRequest>
    {
        public VrstaProizvodaController(IBaseService<MVrstaProizvoda, VrstaProizvodaSearch, VrstaProizvodaUpsertRequest, VrstaProizvodaUpsertRequest> IBaseService) : base(IBaseService)
        {
        }
    }
}
