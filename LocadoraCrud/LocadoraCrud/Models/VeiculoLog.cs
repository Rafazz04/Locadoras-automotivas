using Locadoras.Models;

namespace LocadoraCrud.Models;

public class VeiculoLog
{
    public int VeiculoLogId { get; set; }
    public int VeiculoId { get; set; }
    public string NomeLocadora { get; set; }
    public string NomeModelo { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public Veiculo Veiculo { get; set; }
}
