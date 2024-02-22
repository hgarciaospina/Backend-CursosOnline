using Microsoft.AspNetCore.Mvc;
using Dominio;
using MediatR;
using Aplicacion.Cursos;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
  
  private readonly IMediator _mediator;
  public CursoController(IMediator mediator)
  {
    _mediator = mediator;
  }

  /* http://localhost:5200/api/Curso */ 
  [HttpGet]
  public async Task<ActionResult<List<Curso>>> Get() 
  {
    return await _mediator.Send(new Consulta.ListaCursos());
  }

  /* http://localhost:5200/api/Curso/1 */
  [HttpGet("{id}")]
  public async Task<ActionResult<Curso>> GetById(int id)
  {
    return await  _mediator.Send(new ConsultaPorId.CursoUnico{Id = id});
  }
  [HttpPost]
  public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
  {
    return await _mediator.Send(data);
  }

}