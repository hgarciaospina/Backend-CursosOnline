using Aplicacion.ManejadorError;
using Dominio;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Aplicacion.Seguridad
{
    public class Login
    {
        public class Ejecuta : IRequest<Usuario>
        {
            public required string Email { get; set;}
            public required string Password { get; set; }

        }

        public class EjecutaValidacion : AbstractValidator<Ejecuta> 
        {
            public EjecutaValidacion()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x=> x.Password).NotEmpty();
            }
        }

        public class Manejador : IRequestHandler<Ejecuta, Usuario>
        {
            private readonly UserManager<Usuario> _userManager;
            private readonly SignInManager<Usuario> _signInManager;
            public Manejador(UserManager<Usuario> userManger, SignInManager<Usuario> signInManager)
            {
                _userManager = userManger;
                _signInManager = signInManager;
            }
            public async Task<Usuario> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var usuario = await _userManager.FindByEmailAsync(request.Email); 
                if(usuario == null) 
                {

                    throw new ManejadorExcepcion(
                            HttpStatusCode.Unauthorized,
                            new { usuario  = $"No existe el usuario con email {request.Email }"});
                }

                var resultado = await _signInManager.CheckPasswordSignInAsync(usuario, request.Password, false);
                if (resultado.Succeeded) 
                {
                    return usuario;
                }

                throw new ManejadorExcepcion(
                            HttpStatusCode.Unauthorized,
                            new { usuario = $"usuario no autorizado" });
            }
        }

    }
}
