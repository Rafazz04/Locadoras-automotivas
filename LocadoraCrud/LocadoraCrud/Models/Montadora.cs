using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadoras.Models;
[Table("Montadoras")]
public class Montadora
{
    [Key]
    public int MontadoraId { get; set; }

    [Required]
    [StringLength(200)]
    public string NomeMontadora { get; set; }
    public ICollection<Modelo> Modelos { get; set; }
}
