using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dto;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _Repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper) {
      _Repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> getAll() {
      var commands = this._Repository.GetAllCommands();
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("{id}")]
    public ActionResult<CommandReadDto> getById(int id) {

      var command = this._Repository.GetCommandById(id);

      if(command == null) {
        return NotFound();
      }

      return Ok(_mapper.Map<CommandReadDto>(command));
    }
  }
}