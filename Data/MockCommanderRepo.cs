using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
  public class MockCommanderRepo : ICommanderRepo
  {
    public void CreateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }

    public IEnumerable<Command> GetAllCommands()
    {
      return new List<Command>{
        new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Plataform = "Kettle and pan" },
        new Command { Id = 1, HowTo = "Cut bread", Line = "Get a knife", Plataform = "Knife and chopping bord" },
        new Command { Id = 2, HowTo = "Make cup of tea", Line = "Place teabag in cup", Plataform = "Kettle and cup" },
      };
    }

    public Command GetCommandById(int id)
    {
      return new Command { Id = 0, HowTo = "Boil an egg", Line = "Boil water", Plataform = "Kettle and pan" };
    }

    public bool saveChanges()
    {
      throw new System.NotImplementedException();
    }

    public void UpdateCommand(Command cmd)
    {
      throw new System.NotImplementedException();
    }
  }
}