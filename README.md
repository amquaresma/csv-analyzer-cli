# 📊 CSV Analyzer CLI

> Ferramenta de linha de comando para análise de gastos pessoais a partir de arquivos CSV.

---

## 🖥️ Demonstração
```
=== Bem-vindo ao CSV Analyzer CLI ===

Este programa analisa arquivos CSV de gastos pessoais.

Como usar:
  1. Coloque seu arquivo CSV na pasta /data do projeto
  2. Carregue o arquivo pela opção 1 do menu
  3. Use as opções 2 a 5 para explorar os dados

Formato esperado do CSV:
  data,categoria,descricao,valor
  01/02/2025,alimentacao,mercado,250.00
```
```
=== CSV Analyzer CLI ===

1. Carregar arquivo CSV
2. Exibir dados
3. Estatísticas
4. Filtrar por categoria
5. Gráfico de gastos
0. Sair
```

---

## ✨ Funcionalidades

| Opção | Funcionalidade | Descrição |
|-------|---------------|-----------|
| `1` | Carregar CSV | Lê e carrega qualquer arquivo CSV na memória |
| `2` | Exibir dados | Mostra os dados em formato de tabela no terminal |
| `3` | Estatísticas | Total, média, mediana, min, max e gastos por categoria |
| `4` | Filtrar categoria | Filtra e exibe registros de uma categoria específica |
| `5` | Gráfico de gastos | Gráfico de barras ASCII por categoria |

---

## 🚀 Como rodar

### Pré-requisitos

- [.NET SDK 10+](https://dotnet.microsoft.com/download)
- [VS Code](https://code.visualstudio.com/) com a extensão **C# Dev Kit**

### Instalação
```bash
git clone https://github.com/seu-usuario/csv-analyzer-cli.git
cd csv-analyzer-cli
dotnet run
```

---

## 📁 Estrutura do projeto
```
csv-analyzer-cli/
├── data/
│   └── gastos.csv        # Arquivo de dados (editável)
├── CsvLeitor.cs          # Leitura e parsing do CSV
├── Exibidor.cs           # Exibição em tabela no terminal
├── Estatisticas.cs       # Cálculo de estatísticas
├── Filtro.cs             # Filtragem por categoria
├── Grafico.cs            # Gráfico de barras ASCII
├── Menu.cs               # Menu principal e navegação
├── Program.cs            # Ponto de entrada
└── analyzescvs.csproj    # Configuração do projeto
```

---

## 📄 Formato do CSV
```
data,categoria,descricao,valor
01/02/2025,alimentacao,mercado,250.00
05/02/2025,transporte,uber,35.50
10/02/2025,lazer,cinema,45.00
```

### Regras

- **Data** — formato `DD/MM/AAAA`
- **Categoria** — sem acentos, letras minúsculas
- **Valor** — ponto como separador decimal (ex: `250.00`)
- **Comentários** — linhas com `#` são ignoradas

> 💡 Novas categorias são criadas direto no CSV, sem alterar nenhum arquivo `.cs`

---

## 🧠 Conceitos praticados

- Leitura e parsing de arquivos
- Manipulação de coleções com LINQ
- Estruturas de dados (List, Dictionary)
- Estatísticas básicas (média, mediana, min, max)
- Visualização de dados no terminal (ASCII)

---

## 🛠️ Tecnologias

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![VS Code](https://img.shields.io/badge/VS_Code-007ACC?style=for-the-badge&logo=visualstudiocode&logoColor=white)

---

## 📝 CASO tenha gostado, considere deixar uma estrela!

