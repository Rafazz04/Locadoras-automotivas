using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Locadoras.Models;
[Table("Locadoras")]
public class Locadora
{
    [Key]
    public int LocadoraId { get; set; }

    [Required]
    [StringLength(200)]
    public string NomeFantasia { get; set; }

    [Required]
    [StringLength(200)]
    public string RazaoSocial { get; set; }

    [Required]
    [StringLength(18)]
    public string CNPJ { get; set; }

    [StringLength(150)]
    public string Email { get; set; }

    [StringLength(20)]
    public string Telefone { get; set; }

    [StringLength(10)]
    public string CEP { get; set; }

    [StringLength(300)]
    public string Rua { get; set; }

    [StringLength(100)]
    public string Numero { get; set; }

    [StringLength(300)]
    public string Bairro { get; set; }

    [StringLength(100)]
    public string Estado { get; set; }

    [StringLength(100)]
    public string Cidade { get; set; }
    public ICollection<Veiculo> Veiculos { get; set; }
}
