using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;

namespace NotasAlunosEmCsharp
{
    class Program
    {

        static void Main(string[] args)
        {

            NotasAlunosEmCsharp.RetornoSonoro.RetornarValores();
        }
        public static string CaminhoURL(string arquivo)
        {
            string CaminhoURL = $@"C:\Users\gabri\Documents\Decola Tech\Projetos\Acompanhando Aulas\NotasAlunosEmCsharp\acessAudios\\{arquivo}.mp3";
            return CaminhoURL;
        }

        public static string MenuOpcoes()
        {
            WMPLib.WindowsMediaPlayer voice = new WMPLib.WindowsMediaPlayer();
            voice.URL = @"C:\Users\gabri\Documents\Decola Tech\Projetos\Acompanhando Aulas\NotasAlunosEmCsharp\acessAudios\\MenuOpcoes.mp3";
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1 - Inserir novo aluno\n2 - Listar alunos\n3 - Calcular média geral\nX - Sair\n\n");
            string opcaoUsuario = Console.ReadLine();
            if (opcaoUsuario != "")
            {
                voice.URL = @"";
            }
            return opcaoUsuario;
        }
    }

    }

