// Menu principal do programa
namespace csv_analyzer_cli;

class Menu
{
    private static List<Dictionary<string, string>> _dados = new();
    private static bool _tutorialExibido = false;

    public static void Exibir()
    {
        if (!_tutorialExibido)
        {
            ExibirTutorial();
            _tutorialExibido = true;
        }

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
                case "3": Estatisticas.Exibir(_dados); break;
                case "4": Filtro.FiltrarPorCategoria(_dados); break;
                case "5": Grafico.ExibirBarras(_dados); break;
                case "0": return;
                default: Console.WriteLine("\nOpção inválida."); break;
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }

    private static void ExibirTutorial()
    {
        Console.Clear();
        Console.WriteLine("=== Bem-vindo ao CSV Analyzer CLI ===\n");
        Console.WriteLine("Este programa analisa arquivos CSV de gastos pessoais.\n");
        Console.WriteLine("Como usar:");
        Console.WriteLine("  1. Coloque seu arquivo CSV na pasta /data do projeto");
        Console.WriteLine("  2. Carregue o arquivo pela opção 1 do menu");
        Console.WriteLine("  3. Use as opções 2 a 5 para explorar os dados\n");
        Console.WriteLine("Formato esperado do CSV:");
        Console.WriteLine("  data,categoria,descricao,valor");
        Console.WriteLine("  01/02/2025,alimentacao,mercado,250.00\n");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
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