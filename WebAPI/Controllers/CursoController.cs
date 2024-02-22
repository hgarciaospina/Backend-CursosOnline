using Microsoft.AspNetCore.Mvc;
using Dominio;
using Persistencia;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase
{
  
  private readonly CursosOnlineContext _context;
  public CursoController(CursosOnlineContext context)
  {
    this._context = context;
  }

  [HttpGet]
  public IEnumerable<Curso> Get() => _context.Curso.ToList();
}