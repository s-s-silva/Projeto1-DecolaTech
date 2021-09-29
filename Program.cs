using System;

namespace DIO.Music
{
    class Program
    {
        static MusicRepositorio repositorio = new MusicRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

			while (opcaoUsuario.ToUpper() != "X")
			{
				switch (opcaoUsuario)
				{
					case "1":
						ListarMusic();
						break;
					case "2":
						InserirMusic();
						break;
					case "3":
						AtualizarMusic();
						break;
					case "4":
						ExcluirMusic();
						break;
					case "5":
						VisualizarMusic();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirMusic()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusic = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceMusic);
		}

        private static void VisualizarMusic()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusic = int.Parse(Console.ReadLine());

			var music = repositorio.RetornaPorId(indiceMusic);

			Console.WriteLine(music);
		}

        private static void AtualizarMusic()
		{
			Console.Write("Digite o id da música: ");
			int indiceMusic = int.Parse(Console.ReadLine());

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da música: ");
			string entradaMusica = Console.ReadLine();

			Console.Write("Digite o ano de lançamento da música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite a nome do artista: ");
			string entradaArtista = Console.ReadLine();

			Console.Write("Digite a nota da música: ");
			decimal entradaNota = decimal.Parse(Console.ReadLine());

			Music atualizaMusic = new Music(id: indiceMusic,
										genero: (Genero)entradaGenero,
										musica: entradaMusica,
										ano: entradaAno,
										artista: entradaArtista,
										nota : entradaNota);

			repositorio.Atualiza(indiceMusic, atualizaMusic);
		}
        private static void ListarMusic()
		{
			Console.WriteLine("Listar Musicas");
			var lista = repositorio.Lista();

			Console.WriteLine("\n ***************** SUAS MÚSICAS ***************** \n");
			
			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhuma música cadastrada.");
				return;
			}

			foreach (var music in lista)
			{
				var excluido = music.retornaExcluido(); 
				Console.WriteLine("{0}: {1} - {2} {3}", music.retornaId(), music.retornaMusica(), music.retornaArtista(),(excluido ? "*Excluído*" : ""));
			}

    }

        private static void InserirMusic()
		{
			Console.WriteLine("Inserir nova música");

			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getvalues?view=netcore-3.1
			// https://docs.microsoft.com/pt-br/dotnet/api/system.enum.getname?view=netcore-3.1
			foreach (int i in Enum.GetValues(typeof(Genero)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome da música: ");
			string entradaMusica = Console.ReadLine();

			Console.Write("Digite o ano de lançamento da música: ");
			int entradaAno = int.Parse(Console.ReadLine());

			Console.Write("Digite o nome do artista: ");
			string entradaArtista = Console.ReadLine();

			Console.Write("Digite a nota da música: ");
			decimal entradaNota = decimal.Parse(Console.ReadLine());

			Music novaMusic = new Music(id: repositorio.ProximoId(),
										genero: (Genero)entradaGenero,
										musica: entradaMusica,
										ano: entradaAno,
										artista: entradaArtista,
										nota: entradaNota);

			repositorio.Insere(novaMusic); 
		}

        private static string ObterOpcaoUsuario()
		{
			Console.WriteLine();
			Console.WriteLine("DIO Músicas a seu dispor!!!");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Minhas músicas");
			Console.WriteLine("2- Inserir nova música");
			Console.WriteLine("3- Atualizar música");
			Console.WriteLine("4- Excluir música");
			Console.WriteLine("5- Visualizar música");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}
    }
}
