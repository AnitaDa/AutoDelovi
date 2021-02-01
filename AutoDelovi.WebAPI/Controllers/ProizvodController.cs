using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eAutoDelovi.Model;
using AutoDelovi.WebAPI;
using AutoDelovi.WebAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace AutoDelovi.WebAPI.Controllers
{    [Route("api/[controller]")]
    [ApiController]
    public class ProizvodController : BaseController<MProizvod, ProizvodSearch, ProizvodUpsertRequest, ProizvodUpsertRequest>
    {
        public ProizvodController(IBaseService<MProizvod, ProizvodSearch, ProizvodUpsertRequest, ProizvodUpsertRequest> IBaseService) : base(IBaseService)
        {
        }
    }
}
