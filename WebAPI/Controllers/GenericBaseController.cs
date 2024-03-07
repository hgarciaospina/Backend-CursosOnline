using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenericBaseController : ControllerBase
    {
        private IMediator? _Mediator;
        protected IMediator Mediator => _Mediator ?? (_Mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}