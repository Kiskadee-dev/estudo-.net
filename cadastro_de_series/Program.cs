using System;
using System.Collections;
using cadastro_de_series.Classes;
using cadastro_de_series.Enums;


namespace cadastro_de_series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
                        break;
                    case "2":
                        InserirSerie();
                        break;
                    case "3":
                        AtualizarSerie();
                        break;
                    case "4":
                        ExcluirSerie();
                        break;
                    case "5":
                        VisualizarSerie();
                        break;
                    case "C":
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }

        }
        public static string ObterOpcaoUsuario(){
            Console.WriteLine();
            Console.WriteLine("Registro de séries");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Series");

            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma série cadastrada");
                return;
            }

            foreach (var serie in lista)
            {
                bool excluido = serie.retornaExcluido();
                Console.WriteLine($"#ID: {serie.retornaId()} - {serie.retornaTitulo()} {(excluido ? "- *Excluído*" : "")}");
            }
        }

        private static void InserirSerie()
        {
            Serie novaSerie = obterDados();
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.WriteLine("Atualizar Serie");
            Console.WriteLine("Escolha a série da lista pelo ID");
            ListarSeries();
            Console.Write("Digite o ID: ");
            int id = int.Parse(Console.ReadLine());

            Serie serieAtualizada = obterDados(id);
            
            repositorio.Atualiza(id, serieAtualizada);

        }

        private static Serie obterDados(int _id = -1)
        {

            foreach( int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero), i)}");
            }

            Console.Write("Digite o gênero dentre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano de início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a Descrição da série: ");

            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(
                id: _id == -1 ? repositorio.ProximoId() : _id,
                genero: (Genero)entradaGenero,
                titulo: entradaTitulo,
                ano: entradaAno,
                descricao: entradaDescricao
            );

            return novaSerie;
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Excluir Serie");
            ListarSeries();
            Console.Write("Insira o ID da série a ser excluída");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Tem certeza disso? N/y");
            string confirm = Console.ReadLine().ToUpper();
            if (confirm != "Y")
            {
                Console.WriteLine("Operação Abortada.");
                return;
            }
            repositorio.Exclui(id);
            Console.WriteLine("Série excluída!");
            
        }

        public static void VisualizarSerie()
        {
            Console.WriteLine("Visualizar série");
            ListarSeries();
            Console.Write("Digite o ID da série: ");
            int id = int.Parse(Console.ReadLine());

            Serie serie = repositorio.RetornaPorId(id);

            Console.WriteLine(serie);
        }
    }
}
