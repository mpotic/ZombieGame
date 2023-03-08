﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Back.Game
{
	public class GameSettings : IGameSettings, INotifyPropertyChanged
	{
		bool includedSanta = false;

		bool includedHero = false;

		bool includedHeroine = false;

		public bool IncludedSanta
		{
			get
			{
				return includedSanta;
			}
			set
			{
				includedSanta = value;
				OnPropertyChanged();
			}
		}

		public bool IncludedHero
		{
			get
			{
				return includedHero;
			}
			set
			{
				includedHero = value;
				OnPropertyChanged();
			}
		}

		public bool IncludedHeroine
		{
			get
			{
				return includedHeroine;
			}
			set
			{
				includedHeroine = value;
				OnPropertyChanged();
			}
		}

		public void Configure(bool includeSanta, bool includeHero, bool includeHeroine)
		{
			IncludedSanta = includeSanta;
			IncludedHero = includeHero;
			IncludedHeroine = includeHeroine;
		}

		public event PropertyChangedEventHandler PropertyChanged;

		protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
