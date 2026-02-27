// Exibe gráfico de barras ASCII por categoria
namespace csv_analyzer_cli;

class Grafico
{
    public static void ExibirBarras(List<Dictionary<string, string>> dados)
    {
        if (dados.Count == 0)
        {
            Console.WriteLine("Nenhum dado carregado.");
            return;
        }

        // Soma valores por categoria
        var porCategoria = new Dictionary<string, double>();
        foreach (var registro in dados)
        {
            var cat = registro.ContainsKey("categoria") ? registro["categoria"].Trim() : "outros";
            if (registro.ContainsKey("valor") &&
                double.TryParse(registro["valor"].Trim(), System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.InvariantCulture, out double v))
            {
                if (!porCategoria.ContainsKey(cat)) porCategoria[cat] = 0;
                porCategoria[cat] += v;
            }
        }

        double maximo = porCategoria.Values.Max();
        int larguraBarra = 40;

        Console.WriteLine("\n=== Gráfico de Gastos por Categoria ===\n");

        foreach (var cat in porCategoria.OrderByDescending(c => c.Value))
        {
            int tamanho = (int)(cat.Value / maximo * larguraBarra);
            string barra = new string('█', tamanho);
            Console.WriteLine($"  {cat.Key.PadRight(15)} {barra} R$ {cat.Value:F2}");
        }

        Console.WriteLine();
    }
}