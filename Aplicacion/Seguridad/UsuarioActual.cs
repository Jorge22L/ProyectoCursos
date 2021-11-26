using Aplicacion.Contratos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Aplicacion.Seguridad
{
    public class UsuarioActual 
    {
        public class Ejecutar : IRequest<UsuarioData> { }

        public class Manejador : IRequestHandler<Ejecutar, UsuarioData>
        {
            private readonly UserManager<tblUsuario> _userManager;
            private readonly IJwtGenerador _jwtGenerador;
            private readonly IUsuarioSesion _usuarioSesion;

            public Manejador(UserManager<tblUsuario> userManager, IJwtGenerador jwtGenerador, IUsuarioSesion usuarioSesion)
            {
                _userManager = userManager;
                _jwtGenerador = jwtGenerador;
                _usuarioSesion = usuarioSesion;
            }
            public async Task<UsuarioData> Handle(Ejecutar request, CancellationToken cancellationToken)
            {
                
                var usuario = await _userManager.FindByNameAsync(_usuarioSesion.ObtenerUsuarioSesion());
                    
                return new UsuarioData
                {
                    ID = usuario.Id,
                    NombreCompleto = usuario.NombreCompleto,
                    UserName = usuario.UserName,
                    Token = _jwtGenerador.CrearToken(usuario),
                    Email = usuario.Email,
                    Imagen = null
                };
                
            }
        }
    }
}
