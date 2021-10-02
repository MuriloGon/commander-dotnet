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
    private readonly ICommanderRepo _Repository;

    public CommandsController(ICommanderRepo repository) {
      _Repository = repository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Command>> getAll() => Ok(this._Repository.GetAllCommands());

    [HttpGet("{id}")]
    public ActionResult<Command> getById(int id) {

      var command = this._Repository.GetCommandById(id);

      return Ok(command);
    }
  }
}