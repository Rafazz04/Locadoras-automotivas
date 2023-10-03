using System.Text.RegularExpressions;

namespace LocadoraCrud.Utils;

public static class Util
{
    public static string LimpaFormatacaoCnpj(string cnpj)
    {
        string cnpjDecodificado = Uri.UnescapeDataString(cnpj);
        string cnpjLimpo = Regex.Replace(cnpjDecodificado, "[^0-9]", "");

        return cnpjLimpo;
    }
    public static string RemoverEspacosIgnoreCase(string input)
    {
        if (input == null)
            return null;

        return Regex.Replace(input.Trim(), @"\s+", string.Empty, RegexOptions.IgnoreCase);
    }
    public static string LimpaFormatacaoPlaca(string placa)
    {
        RemoverEspacosIgnoreCase(placa);
        return Regex.Replace(placa, "[^a-zA-Z0-9]", "");
    }

    public static string LimpaFormatacaoChassi(string chassi)
    {
        RemoverEspacosIgnoreCase(chassi);
        string chassiDecodificado = Uri.UnescapeDataString(chassi);
        return Regex.Replace(chassiDecodificado, "[^a-zA-Z0-9[^IOQ]]", "");
    }
    public static bool IsValidCnpj(this string it) => new Regex("([0-9]{2}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[\\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\\.]?[0-9]{3}[\\.]?[0-9]{3}[-]?[0-9]{2})").IsMatch(it);
    public static bool IsValidTelefone(this string it) => new Regex("^[1-9]{2}9?[0-9]{8}$").IsMatch(it);
}
