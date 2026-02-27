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
            .Select(r => r["categoria"])
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        Console.WriteLine("\nCategorias disponíveis:");
        for (int i = 0; i < categorias.Count; i++)
            Console.WriteLine($"  {i + 1}. {categorias[i]}");

        Console.Write("\nDigite a categoria: ");
        var entrada = Console.ReadLine()?.Trim().ToLower();

        var filtrados = dados
            .Where(r => r.ContainsKey("categoria") && r["categoria"].ToLower() == entrada)
            .ToList();

        if (filtrados.Count == 0)
        {
            Console.WriteLine("Nenhum registro encontrado para essa categoria.");
            return;
        }

        Exibidor.ExibirTabela(filtrados);

        // Total da categoria
        double total = filtrados
            .Where(r => r.ContainsKey("valor") &&
                double.TryParse(r["valor"], System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out _))
            .Sum(r => double.Parse(r["valor"], System.Globalization.CultureInfo.InvariantCulture));

        Console.WriteLine($"Total da categoria: R$ {total:F2}");
    }
}