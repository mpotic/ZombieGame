﻿using Back.Dice;
using Back.PlayerModel;
using Back.PlayerModel.Singleton;
using Back.PlayerModel.Visitor;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Back.Game
{
	public class Game : IGame, INotifyPropertyChanged
	{
		private IPlayer currentPlayer;

		private IScoreDecorator scoreDecorator;

		private IHand hand;

		private IGameSettings gameSettings;

		private IBag bag;

		private bool killed;

		public IScoreDecorator ScoreDecorator { get => scoreDecorator; set => scoreDecorator = value; }

		public IPlayer CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

		public IHand Hand { get => hand; set => hand = value; }

		public IBag Bag { get => bag; set => bag = value; }

		public IGameSettings GameSettings { get => gameSettings; set => gameSettings = value; }

		public bool Killed
		{
			get => killed;
			set
			{
				killed = value;
				OnPropertyChanged();
			}
		}

		public Game()
		{
			scoreDecorator = new ScoreDecorator();
			hand = new Hand();
			gameSettings = new GameSettings();
			bag = new Bag();
		}

		public void SetupNewGame(bool includeSanta = false, bool includeHero = false, bool includeHeroine = false)
		{
			GameSettings.Configure(includeSanta, includeHero, includeHeroine);

			IScoreDecorator currentDecorator = new ScoreDecorator();

			if (GameSettings.IncludedSanta)
			{
				IScoreDecorator santaDecorator = new SantaScoreDecorator();
				santaDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = santaDecorator;
			}

			if (GameSettings.IncludedHero)
			{
				IScoreDecorator heroDecorator = new ScoreDecoratorHero();
				heroDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = heroDecorator;
			}

			if (GameSettings.IncludedHeroine)
			{
				IScoreDecorator heroineDecorator = new ScoreDecoratorHeroine();
				heroineDecorator.SetScoreComponent(currentDecorator);
				currentDecorator = heroineDecorator;
			}

			ScoreDecorator = currentDecorator;

			StartGame();
		}

		public void StopAction()
		{
			currentPlayer.Accept(new SaveTurnPlayerVisitor());
			currentPlayer.Accept(new ChangePlayerVisitor());
			ScoreDecorator.ResetScore();
			Bag.ResetBag();
		}

		public void RollAction()
		{
			Hand.GrabAndRollDice();
			ScoreDecorator.UpdateScore();
			ScoreDecorator.CheckAndKill();
		}

		public void ResetGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag();
			CurrentPlayer = null;
			PlayerListSingleton.instance.PlayersList.RemoveAllPlayers();
		}

		public void StartGame()
		{
			ScoreDecorator.ResetScore();
			Bag.ResetBag();
			PlayerListSingleton.instance.PlayersList.ResetPlayersScore();
			CurrentPlayer = PlayerListSingleton.instance.PlayersList.Players.FirstOrDefault();
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
