using Microsoft.AspNetCore.Mvc;
using Dominio;
using MediatR;
using Aplicacion.Cursos;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursosController : GenericBaseController
{
  

  /* http://localhost:5200/api/Cursos */ 
  [HttpGet]
  public async Task<ActionResult<List<Curso>>> Get() 
  {
    return await Mediator.Send(new Consulta.ListaCursos());
  }

  /* http://localhost:5200/api/Cursos/1 */
  [HttpGet("{id}")]
  public async Task<ActionResult<Curso>> GetById(int id)
  {
    return await  Mediator.Send(new ConsultaPorId.CursoUnico{Id = id});
  }

  /* http://localhost:5200/api/Cursos */
  [HttpPost]
  public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
  {
    return await Mediator.Send(data);
  }

  /* http://localhost:5200/api/Cursos/1 */
  [HttpPut("{id}")]
  public async Task<ActionResult<Unit>> Editar(int id, Editar.Ejecuta data)
  {
    data.CursoId = id;
    return await  Mediator.Send(data);
  }

  /* http://localhost:5200/api/Cursos/1 */
  [HttpDelete("{id}")]
  public async Task<ActionResult<Unit>> Eliminar(int id)
  {
    return await Mediator.Send(new Eliminar.Ejecuta{Id = id});
  }
}