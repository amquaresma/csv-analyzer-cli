// Responsável por ler e interpretar o arquivo CSV
namespace csv_analyzer_cli;

class CsvLeitor
{
    public static List<Dictionary<string, string>> Carregar(string caminho)
    {
        var registros = new List<Dictionary<string, string>>();

        if (!File.Exists(caminho))
        {
            Console.WriteLine("Arquivo não encontrado.");
            return registros;
        }

        var linhas = File.ReadAllLines(caminho);

        if (linhas.Length < 2)
        {
            Console.WriteLine("Arquivo vazio ou sem dados.");
            return registros;
        }

        var colunas = linhas[0].Split(',');

        for (int i = 1; i < linhas.Length; i++)
        {
            var valores = linhas[i].Split(',');
            var registro = new Dictionary<string, string>();

            for (int j = 0; j < colunas.Length; j++)
            {
                registro[colunas[j].Trim()] = j < valores.Length ? valores[j].Trim() : "";
            }

            registros.Add(registro);
        }

        return registros;
    }
}