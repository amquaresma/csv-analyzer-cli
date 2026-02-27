// Filtra os dados por categoria
namespace csv_analyzer_cli;

class Filtro
{
    public static void FiltrarPorCategoria(List<Dictionary<string, string>> dados)
    {
        if (dados.Count == 0)
        {
            Console.WriteLine("Nenhum dado carregado.");
            return;
        }

        // Lista categorias disponíveis
        var categorias = dados
            .Where(r => r.ContainsKey("categoria"))
            .Select(r => r["categoria"].Trim())
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        Console.WriteLine("\nCategorias disponíveis:");
        for (int i = 0; i < categorias.Count; i++)
            Console.WriteLine($"  {i + 1}. {categorias[i]}");

        Console.Write("\nDigite o número da categoria: ");
        var entrada = Console.ReadLine()?.Trim();

        if (!int.TryParse(entrada, out int indice) || indice < 1 || indice > categorias.Count)
        {
            Console.WriteLine("Opção inválida.");
            return;
        }

        var categoriaSelecionada = categorias[indice - 1];

        var filtrados = dados
            .Where(r => r.ContainsKey("categoria") && r["categoria"].Trim() == categoriaSelecionada)
            .ToList();

        if (filtrados.Count == 0)
        {
            Console.WriteLine("Nenhum registro encontrado.");
            return;
        }

        Exibidor.ExibirTabela(filtrados);

        double total = filtrados
            .Where(r => r.ContainsKey("valor") &&
                double.TryParse(r["valor"].Trim(), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out _))
            .Sum(r => double.Parse(r["valor"].Trim(), System.Globalization.CultureInfo.InvariantCulture));

        Console.WriteLine($"Total da categoria: R$ {total:F2}");
    }
}