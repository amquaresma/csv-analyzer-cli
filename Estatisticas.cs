// Calcula estatísticas dos dados carregados
namespace csv_analyzer_cli;

class Estatisticas
{
    public static void Exibir(List<Dictionary<string, string>> dados)
    {
        if (dados.Count == 0)
        {
            Console.WriteLine("Nenhum dado carregado.");
            return;
        }

        // Tenta encontrar coluna numérica de valor
        var colunaValor = "valor";

        var valores = new List<double>();
        foreach (var registro in dados)
        {
            if (registro.ContainsKey(colunaValor) &&
                double.TryParse(registro[colunaValor], System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double v))
                valores.Add(v);
        }

        if (valores.Count == 0)
        {
            Console.WriteLine("Nenhum valor numérico encontrado.");
            return;
        }

        valores.Sort();

        double soma = valores.Sum();
        double media = soma / valores.Count;
        double min = valores.First();
        double max = valores.Last();
        double mediana = valores.Count % 2 == 0
            ? (valores[valores.Count / 2 - 1] + valores[valores.Count / 2]) / 2
            : valores[valores.Count / 2];

        // Gastos por categoria
        var porCategoria = new Dictionary<string, double>();
        foreach (var registro in dados)
        {
            var cat = registro.ContainsKey("categoria") ? registro["categoria"] : "outros";
            if (registro.ContainsKey(colunaValor) &&
                double.TryParse(registro[colunaValor], System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double v))
            {
                if (!porCategoria.ContainsKey(cat)) porCategoria[cat] = 0;
                porCategoria[cat] += v;
            }
        }

        Console.WriteLine("\n=== Estatísticas ===\n");
        Console.WriteLine($"  Total gasto:  R$ {soma:F2}");
        Console.WriteLine($"  Média:        R$ {media:F2}");
        Console.WriteLine($"  Mediana:      R$ {mediana:F2}");
        Console.WriteLine($"  Menor gasto:  R$ {min:F2}");
        Console.WriteLine($"  Maior gasto:  R$ {max:F2}");
        Console.WriteLine($"  Registros:    {valores.Count}");

        Console.WriteLine("\n  Por categoria:");
        foreach (var cat in porCategoria.OrderByDescending(c => c.Value))
            Console.WriteLine($"    {cat.Key.PadRight(15)} R$ {cat.Value:F2}");
    }
}