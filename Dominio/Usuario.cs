using Microsoft.AspNetCore.Identity;

namespace Dominio
{
    public class Usuario : IdentityUser
    {
        public required string NombreCompleto { get; set; }
    }
}
