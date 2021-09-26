using System.Collections.Generic;
using Commander.Data;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly MockCommanderRepo _repo = new MockCommanderRepo(); 

    [HttpGet]
    public ActionResult<IEnumerable<Command>> getAll() => Ok(this._repo.GetAppsCommands());

    [HttpGet("{id}")]
    public ActionResult<Command> getById(int id) {

      var commands = this._repo.GetCommandById(id);

      return Ok();
    }
  }
}