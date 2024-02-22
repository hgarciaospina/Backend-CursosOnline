using Microsoft.AspNetCore.Mvc;
using Dominio;
using MediatR;
using Aplicacion.Cursos;

namespace WebAPI.Controllers;

[ApiController]
//http://loclahost:5200/api/Cursos
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
  
  private readonly IMediator _mediator;
  public CursoController(IMediator mediator)
  {
    _mediator = mediator;
  }

  [HttpGet]
  public async Task<ActionResult<List<Curso>>> Get() {
    return await _mediator.Send(new Consulta.ListaCursos());
  }
}