// Menu principal do programa
namespace csv_analyzer_cli;

class Menu
{
    private static List<Dictionary<string, string>> _dados = new();

    public static void Exibir()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== CSV Analyzer CLI ===\n");
            Console.WriteLine("1. Carregar arquivo CSV");
            Console.WriteLine("2. Exibir dados");
            Console.WriteLine("3. Estatísticas");
            Console.WriteLine("4. Filtrar por categoria");
            Console.WriteLine("5. Gráfico de gastos");
            Console.WriteLine("0. Sair\n");
            Console.Write("Escolha uma opção: ");

            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": CarregarCsv(); break;
                case "2": Exibidor.ExibirTabela(_dados); break;
                case "3": Console.WriteLine("\n[em breve]"); break;
                case "4": Console.WriteLine("\n[em breve]"); break;
                case "5": Console.WriteLine("\n[em breve]"); break;
                case "0": return;
                default: Console.WriteLine("\nOpção inválida."); break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void CarregarCsv()
    {
        Console.Write("\nCaminho do arquivo (ex: data/gastos.csv): ");
        var caminho = Console.ReadLine();

        _dados = CsvLeitor.Carregar(caminho ?? "");

        if (_dados.Count > 0)
            Console.WriteLine($"{_dados.Count} registros carregados com sucesso!");
    }
}