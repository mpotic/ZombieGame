using System.Collections.Generic;

namespace Back.PlayerModel
{
	public interface IPlayerList
	{
		List<IPlayer> Players { get; set; }
		
		void AddPlayer(string name);
		
		void ResetPlayersScore();

		void RemoveAllPlayers();
	}
}
