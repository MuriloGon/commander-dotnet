using System.ComponentModel.DataAnnotations;

namespace Commander.Models {
  public class Command {
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string HowTo { get; set; }

    [Required]
    [MaxLength(200)]
    public string Line { get; set; }

    [Required]
    [MaxLength(200)]
    public string Plataform { get; set; }
  }
}