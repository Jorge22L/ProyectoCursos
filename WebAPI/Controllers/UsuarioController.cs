using Aplicacion.Seguridad;
using Dominio;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [AllowAnonymous]
    public class UsuarioController : MiControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<UsuarioData>> Login(Login.Ejecuta data)
        {
            return await Mediator.Send(data);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult<UsuarioData>> Registrar(Registrar.Ejecuta paametros)
        {
            return await Mediator.Send(paametros);
        }
    }
}
