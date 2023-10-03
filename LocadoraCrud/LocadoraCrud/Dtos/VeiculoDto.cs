using Locadoras.Models;

namespace Locadoras.Dtos;

public class VeiculoDto
{
    public string NumeroPortas { get; set; }
    public string NomeModelo { get; set; }
    public string Cor { get; set; }
    public string Fabricante { get; set; }
    public string AnoModelo { get; set; }
    public string AnoFabricacao { get; set; }
    public string Placa { get; set; }
    public string Chassi { get; set; }
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public string NomeLocadora { get; set; }
}


