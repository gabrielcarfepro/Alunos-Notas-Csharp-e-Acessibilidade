using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NotasAlunosEmCsharp
{
    public class RetornoSonoro
    {
        public static void RetornarValores()
        {
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = Program.MenuOpcoes();
            WMPLib.WindowsMediaPlayer voiceRetorno = new WMPLib.WindowsMediaPlayer();
            ConsoleKey key;
            ConsoleKeyInfo keyInfo;

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("\n\nInforme o nome do aluno:");
                        voiceRetorno.URL = Program.CaminhoURL("InserirAluno");
                        System.Threading.Thread.Sleep(2000);
                        voiceRetorno.URL = Program.CaminhoURL("InfoNome");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");
                        voiceRetorno.URL = Program.CaminhoURL("InfoNota");
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            voiceRetorno.URL = Program.CaminhoURL("Erro valor decimal");
                            throw new ArgumentException("Valor da nota deve ser decimal!");
                        }
                        if(aluno.Nota != null)
                        {
                            voiceRetorno.URL = Program.CaminhoURL("");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        Console.WriteLine();
                        break;
                    case "2":
                        voiceRetorno.URL = Program.CaminhoURL("ListarAlunos");
                        System.Threading.Thread.Sleep(2000);
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                            {
                                Console.WriteLine($"ALUNO: {a.Nome} - NOTA {a.Nota}\n\n");
                                voiceRetorno.URL = Program.CaminhoURL(a.Nome);
                                System.Threading.Thread.Sleep(2000);
                                voiceRetorno.URL = Program.CaminhoURL("nota");
                                System.Threading.Thread.Sleep(1000);
                                voiceRetorno.URL = Program.CaminhoURL(a.Nota.ToString());
                                System.Threading.Thread.Sleep(2500);
                            }
                        }
                        break;
                    case "3":
                        decimal notaTotal = 0;
                        var NumeroDeAlunos = 0;
                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                NumeroDeAlunos++;

                            }
                        }

                        var mediaGeral = notaTotal / NumeroDeAlunos;
                        Console.WriteLine($"A média geral é: {mediaGeral}\n\n");
                        voiceRetorno.URL = Program.CaminhoURL("MediaGeral");
                        System.Threading.Thread.Sleep(2000);
                        voiceRetorno.URL = Program.CaminhoURL(mediaGeral.ToString());
                        System.Threading.Thread.Sleep(2000);
                        voiceRetorno.URL = Program.CaminhoURL("BoletimDaTurma");
                        System.Threading.Thread.Sleep(2000);
                        ConceitoEnum conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = ConceitoEnum.E;
                            Console.WriteLine("Boletim da turma é: E");
                            voiceRetorno.URL = Program.CaminhoURL("E");
                            System.Threading.Thread.Sleep(1400);
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = ConceitoEnum.D;
                            Console.WriteLine("Boletim da turma é: D");
                            voiceRetorno.URL = Program.CaminhoURL("D");
                            System.Threading.Thread.Sleep(1400);
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = ConceitoEnum.C;
                            Console.WriteLine("Boletim da turma é: C");
                            voiceRetorno.URL = Program.CaminhoURL("C");
                            System.Threading.Thread.Sleep(1400);
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = ConceitoEnum.B;
                            Console.WriteLine("Boletim da turma é: B");
                            voiceRetorno.URL = Program.CaminhoURL("B");
                            System.Threading.Thread.Sleep(1400);
                        }
                        else if (mediaGeral <= 10)
                        {
                            conceitoGeral = ConceitoEnum.A;
                            Console.WriteLine("Boletim da turma é: A");
                            voiceRetorno.URL = Program.CaminhoURL("A");
                            System.Threading.Thread.Sleep(1400);
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = Program.MenuOpcoes();
            }
            voiceRetorno.URL = Program.CaminhoURL("ExitSoftware");
            System.Threading.Thread.Sleep(2000);
        }


    }
}
