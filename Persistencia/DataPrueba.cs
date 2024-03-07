using Azure.Identity;
using Dominio;
using Microsoft.AspNetCore.Identity;

namespace Persistencia
{
    public class DataPrueba
    {
        public static async Task InsertarData(CursosOnlineContext context, UserManager<Usuario> usuarioManager)
        {
            if (!usuarioManager.Users.Any())
            {
                var usuario = new Usuario
                {
                    NombreCompleto = "Henry García Ospina",
                    UserName = "hegaro",
                    Email = "henrygarciaospina@gmail.com"
                };
                await usuarioManager.CreateAsync(usuario, "Leandro2009*");
            }
        }
    }
}