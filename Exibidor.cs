// Responsável por exibir os dados no terminal
namespace csv_analyzer_cli;

class Exibidor
{
    public static void ExibirTabela(List<Dictionary<string, string>> dados)
    {
        if (dados.Count == 0)
        {
            Console.WriteLine("Nenhum dado carregado.");
            return;
        }

        var colunas = new List<string>(dados[0].Keys);

        // Calcula largura de cada coluna
        var larguras = new Dictionary<string, int>();
        foreach (var col in colunas)
            larguras[col] = col.Length;

        foreach (var registro in dados)
            foreach (var col in colunas)
                if (registro[col].Length > larguras[col])
                    larguras[col] = registro[col].Length;

        // Linha separadora
        string Separador() => "+" + string.Join("+", colunas.Select(c => new string('-', larguras[c] + 2))) + "+";

        // Cabeçalho
        Console.WriteLine(Separador());
        Console.WriteLine("| " + string.Join(" | ", colunas.Select(c => c.PadRight(larguras[c]))) + " |");
        Console.WriteLine(Separador());

        // Linhas
        foreach (var registro in dados)
        {
            Console.WriteLine("| " + string.Join(" | ", colunas.Select(c => registro[c].PadRight(larguras[c]))) + " |");
        }

        Console.WriteLine(Separador());
        Console.WriteLine($"\nTotal: {dados.Count} registros.");
    }
}