using System;

namespace projeto_basico
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            int indiceAluno = 0;
            string OpcaoUsuario = ExibirMenu();

            while (OpcaoUsuario != "X")
            {
                switch(OpcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();
                        Console.WriteLine("Informe a nota do aluno: ");

                        if (decimal.TryParse(Console.ReadLine(), out decimal Nota))
                        {
                            aluno.Nota = Nota; 
                        }else{
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach(Aluno a in alunos){
                            if (!string.IsNullOrEmpty(a.Nome)) {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;
                    case "3":
                        //TODO: Calcular média geral
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                OpcaoUsuario = ExibirMenu();
            }
        }

        private static string ExibirMenu(){
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("1- Inserir novo aluno");
            Console.WriteLine("2- Listar alunos");
            Console.WriteLine("3- Calcular média geral");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            string input = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return input;
        }
    }
}
