using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Locadoras.Models;
[Table("Modelos")]
public class Modelo
{
    [Key]
    public int ModeloId { get; set; }

    [Required]
    [StringLength(100)]
    public string NomeModelo { get; set; }

    [ForeignKey("Montadora")]
    public int MontadoraId { get; set; }

    public Montadora Montadora { get; set; }
    public ICollection<Veiculo> Veiculos { get; set; }
}
