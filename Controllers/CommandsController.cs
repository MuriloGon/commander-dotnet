using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Dto;
using Commander.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{
  [Route("api/commands")]
  [ApiController]
  public class CommandsController : ControllerBase
  {
    private readonly ICommanderRepo _Repository;
    private readonly IMapper _mapper;

    public CommandsController(ICommanderRepo repository, IMapper mapper)
    {
      _Repository = repository;
      _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<CommandReadDto>> getAll()
    {
      var commands = this._Repository.GetAllCommands();
      return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
    }

    [HttpGet("{id}", Name = "getById")]
    public ActionResult<CommandReadDto> getById(int id)
    {

      var command = this._Repository.GetCommandById(id);

      if (command == null)
      {
        return NotFound();
      }

      return Ok(_mapper.Map<CommandReadDto>(command));
    }

    [HttpPost]
    public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto cmdCreate)
    {
      var commandModel = _mapper.Map<Command>(cmdCreate);
      _Repository.CreateCommand(commandModel);

      _Repository.saveChanges();

      return CreatedAtRoute(
        nameof(getById),
        new { id = commandModel.Id },
        commandModel
      );
    }

    [HttpPut("{id}")]
    public ActionResult<CommandReadDto> UpdateCommand(int id, CommandUpdateDto cmdUpdte)
    {
      var cmdFromRepo = _Repository.GetCommandById(id);

      if (cmdFromRepo == null) return NotFound();

      _mapper.Map(cmdUpdte, cmdFromRepo);

      _Repository.UpdateCommand(cmdFromRepo);
      _Repository.saveChanges();

      return NoContent();
    }

    [HttpPatch("{id}")]
    public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
    {
      var cmdFromRepo = _Repository.GetCommandById(id);
      if (cmdFromRepo == null) return NotFound();

      var commandToPatch = _mapper.Map<CommandUpdateDto>(cmdFromRepo);
      patchDoc.ApplyTo(commandToPatch, ModelState);

      if (!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);
      _mapper.Map(commandToPatch, cmdFromRepo);

      _Repository.UpdateCommand(cmdFromRepo);
      _Repository.saveChanges();

      return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteCommand(int id)
    {
      var cmdFromRepo = _Repository.GetCommandById(id);
      if (cmdFromRepo == null) return NotFound();

      _Repository.DeleteCommand(cmdFromRepo);
      _Repository.saveChanges();

      return NoContent();
    }
  }
}