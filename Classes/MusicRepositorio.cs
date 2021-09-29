using System;
using System.Collections.Generic;
using DIO.Music.Interfaces;

namespace DIO.Music
{
	public class MusicRepositorio : IRepositorio<Music>
	{
        private List<Music> listaMusic = new List<Music>();
		public void Atualiza(int id, Music objeto)
		{
			listaMusic[id] = objeto;
		}

		public void Exclui(int id)
		{
			listaMusic[id].Excluir();
		}

		public void Insere(Music objeto)
		{
			listaMusic.Add(objeto);
		}

		public List<Music> Lista()
		{
			return listaMusic;
		}

		public int ProximoId()
		{
			return listaMusic.Count;
		}

		public Music RetornaPorId(int id)
		{
			return listaMusic[id];
		}
	}
}