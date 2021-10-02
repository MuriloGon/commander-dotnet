using AutoMapper;
using Commander.Dto;
using Commander.Models;

namespace Commander.Profiles
{
  public class CommandsProfile : Profile
  {
    public CommandsProfile() {
      CreateMap<Command, CommandReadDto>();
      CreateMap<CommandCreateDto, Command>();
    }
  }
}