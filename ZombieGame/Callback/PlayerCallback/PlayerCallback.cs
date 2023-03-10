using ViewModel.Callback;

namespace ZombieGame.Callback
{
	/// <summary>
	/// Used for switching between players as the UI elements.
	/// </summary>
	public class PlayerCallback : IPlayerCallback
	{
		public PlayerCallback() 
		{ 
		}

		public void ChangeActivePlayer(int current)
		{
			PlayerListViewElementSingleton.PlayersList.Dispatcher.Invoke(() => 
			{
				PlayerListViewElementSingleton.PlayersList.SelectedIndex = current;
			});
		}
	}
}