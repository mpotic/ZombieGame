using Back.Dice;
using System.Collections.Generic;

namespace Back.Game
{
	public class ScoreDecorator : IScoreDecorator
	{
		private IScore scoreComponent;

		public IScore ScoreComponent { get => scoreComponent; set => scoreComponent = value; }

		public int BrainsCount
		{
			get
			{
				return ScoreComponent.BrainsCount;
			}
			set
			{
				ScoreComponent.BrainsCount = value;
			}
		}

		public int ShotgunCount
		{
			get
			{
				return ScoreComponent.ShotgunCount;
			}
			set
			{
				ScoreComponent.ShotgunCount = value;
			}
		}

		public bool Killed
		{
			get
			{
				return ScoreComponent.Killed;
			}
			set
			{
				ScoreComponent.Killed = value;
			}
		}

		public List<IDice> AllRolledDice
		{
			get
			{
				return ScoreComponent.AllRolledDice;
			}
			set
			{
				ScoreComponent.AllRolledDice = value;
			}
		}

		public virtual void CheckAndKill()
		{
			ScoreComponent.CheckAndKill();
		}

		public virtual void PlayerKilled()
		{
			ScoreComponent.PlayerKilled();
		}

		public virtual void ResetScore()
		{
			ScoreComponent.ResetScore();
		}

		public virtual void UpdateScore()
		{
			ScoreComponent.UpdateScore();
		}

		public virtual void RemoveDice(IDice dice)
		{
			ScoreComponent.RemoveDice(dice);
		}

		public virtual void SetScoreComponent(IScore score)
		{
			ScoreComponent = score;
		}
	}
}
