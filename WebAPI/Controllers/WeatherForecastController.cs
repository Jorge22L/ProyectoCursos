using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    //localhost:5000/WeatherForecast
    public class WeatherForecastController : ControllerBase
    {
        private readonly CursosContext context;

        public WeatherForecastController(CursosContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public IEnumerable<tblCurso> Get()
        {
            return context.tblCurso.ToList();
        }
    }
}
