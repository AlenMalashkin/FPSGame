using Code.Data.Models.GameModel;
using Code.Logic.GameWorld;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Logic.Loot
{
	public class RandomLootSpawner : MonoBehaviour, IGameWorldPart
	{
		[SerializeField] private Loot[] allLoot;

		private IGameModel _gameModel;
		private DiContainer _diContainer;
		
		[Inject]
		private void Construct(IGameModel gameModel, DiContainer diContainer)
		{
			_gameModel = gameModel;
			_diContainer = diContainer;
		}
		
		public void Initialize()
		{
			_gameModel.RandomLootSpawner = this;
		}

		public void SpawnRandomLoot(Vector3 at)
		{
			_diContainer.InstantiatePrefab(allLoot[Random.Range(0, allLoot.Length)], at, Quaternion.identity, transform);
		}
	}
}