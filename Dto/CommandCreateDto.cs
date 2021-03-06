using System.ComponentModel.DataAnnotations;

namespace Commander.Dto
{
  public class CommandCreateDto
  {
    [Required]
    public string HowTo { get; set; }

    [Required]
    public string Line { get; set; }

    [Required]
    public string Plataform { get; set; }
  }
}