using System;

namespace projeto_basico
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();

            while (OpcaoUsuario != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        //TODO: Inserir novo aluno
                        break;
                    case "2":
                        //TODO: Listar alunos
                        break;
                    case "3":
                        //TODO: Calcular média geral
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Console.WriteLine("Informe a opção desejada");
                Console.WriteLine("1- Inserir novo aluno");
                Console.WriteLine("2- Listar alunos");
                Console.WriteLine("3- Calcular média geral");
                Console.WriteLine("X- Sair");
                Console.WriteLine();
                OpcaoUsuario = Console.ReadLine().ToUpper();
            }
        }
    }
}
