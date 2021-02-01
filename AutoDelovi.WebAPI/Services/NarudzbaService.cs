using eAutoDelovi.Model;
using AutoDelovi.WebAPI.Databases;
using AutoDelovi.WebAPI.Services;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace AutoDelovi.WebAPI.Services.Narudzba
{
    public class NarudzbaService:BaseServices<object,NarudzbaSearch,NarudzbaUpsertRequest, NarudzbaUpsertRequest,Databases.Narudzba>
    {
        public NarudzbaService(AutoDeloviiContext context, IMapper mapper) : base(context, mapper) { }
    }
}
