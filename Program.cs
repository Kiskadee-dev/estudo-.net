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
                        decimal notaTotal = 0;
                        int nrAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome)) 
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }    
                        }

                        decimal mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }else{
                            conceitoGeral = Conceito.A;
                        }

                        
                        Console.WriteLine($"Media: {mediaGeral} - CONCEITO: {conceitoGeral}");

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
