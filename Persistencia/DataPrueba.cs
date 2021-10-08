using Dominio;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertarData(CursosContext context, UserManager<tblUsuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new tblUsuario { NombreCompleto = "Jorge Morales", UserName = "jorgel", Email = "jorgeluisreyes@doc.uca.edu.ni" };
                await usuarioManager.CreateAsync(usuario, "Password1234$");
            }
        }
    }
}
