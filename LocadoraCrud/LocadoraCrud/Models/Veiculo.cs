using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Locadoras.Models;
[Table("Veiculos")]
public class Veiculo
{
    [Key]
    public int VeiculoId { get; set; }

    [StringLength(10)]
    public string NumeroPortas { get; set; }
    public int ModeloId { get; set; }
    public Modelo Modelo { get; set; }

    [StringLength(50)]
    public string Cor { get; set; }

    [StringLength(200)]
    public string Fabricante { get; set; }

    [StringLength(20)]
    public string AnoModelo { get; set; }

    [StringLength(20)]
    public string AnoFabricacao { get; set; }

    [StringLength(200)]
    public string Placa { get; set; }

    [StringLength(200)]
    public string Chassi { get; set; }

    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public int? LocadoraId { get; set; }
    public Locadora Locadora { get; set; }
}
