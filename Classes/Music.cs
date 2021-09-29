using System;

namespace DIO.Music
{
    public class Music : EntidadeBase //herda da entidade base(id)
    {
        // Atributos
		private Genero Genero { get; set; }
		private string Musica { get; set; }
		private string Artista { get; set; }
		private int Ano { get; set; }
        private bool Excluido {get; set;}
		private decimal Nota{get; set;}

        // Métodos
		public Music(int id, Genero genero, string musica, string artista, int ano, decimal nota)
		{
			this.Id = id;
			this.Genero = genero;
			this.Musica = musica;
			this.Artista = artista;
			this.Ano = ano;
            this.Excluido = false;
			this.Nota = nota;
		}

        public override string ToString()
		{
			// Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Musica: " + this.Musica + Environment.NewLine;
            retorno += "Artista: " + this.Artista + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
			retorno += "Nota: " + this.Nota + Environment.NewLine;
			return retorno;
		}

        public string retornaMusica()
		{
			return this.Musica;
		}
		public string retornaArtista()
		{
			return this.Artista;
		}
		public int retornaId()
		{
			return this.Id;
		}
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public void Excluir() {
            this.Excluido = true;
        }
    }
}