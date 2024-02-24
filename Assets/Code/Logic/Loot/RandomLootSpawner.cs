using System.Collections.Generic;
using System.Linq;
using Code.Data.Models.GameModel;
using Code.Infrastructure.Factory;
using Code.Logic.GameWorld;
using UnityEngine;
using Zenject;
using Random = System.Random;

namespace Code.Logic.Loot
{
	public class RandomLootSpawner : MonoBehaviour, IGameWorldPart
	{
		[SerializeField] private Loot[] allLoot;

		private IGameModel _gameModel;
		private IGameFactory _gameFactory;
		
		[Inject]
		private void Construct(IGameModel gameModel, IGameFactory gameFactory)
		{
			_gameModel = gameModel;
			_gameFactory = gameFactory;
		}

		private LootType GetRandomLootType()
		{
			Random random = new Random();
			var randomNum = random.Next(0, 100);

			if (IsNumInRange(70, 100, randomNum))
				return LootType.Money;

			if (IsNumInRange(30, 70, randomNum))
				return LootType.Bullet;
			
			return LootType.Health;
		}

		private bool IsNumInRange(int minRange, int maxRange, int numInRange)
		{
			IEnumerable<int> range = Enumerable.Range(minRange, maxRange);

			foreach (var num in range)
			{
				if (num == numInRange)
					return true;
			}

			return false;
		}
		
		public void Initialize()
		{
			_gameModel.RandomLootSpawner = this;
		}

		public void SpawnRandomLoot(Vector3 at)
		{
			_gameFactory.CreateLoot(GetRandomLootType(), at, transform);
		}
	}
}