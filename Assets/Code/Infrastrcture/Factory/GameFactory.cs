using Code.Data.Models.GameModel;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private DiContainer _diContainer;
		private IGameModel _gameModel;
		
		[Inject]
		private void Construct(DiContainer diContainer, IGameModel gameModel)
		{
			_diContainer = diContainer;
			_gameModel = gameModel;
		}
		
		public GameObject CreatePlayer(Transform at)
		{
			GameObject player = _diContainer.InstantiatePrefabResource(PrefabsPaths.PlayerPrefabPath, at);
			_gameModel.Player = player;
			return player;
		}

		public GameObject CreateHud(Transform at)
		{
			return _diContainer.InstantiatePrefabResource(PrefabsPaths.HUDPrefabPath, at);
		}

		public GameObject CreateEnemySpawner(Transform at)
		{
			return _diContainer.InstantiatePrefabResource(PrefabsPaths.EnemySpawnerPrefabPath, at.position, Quaternion.identity, at);
		}

		public GameObject CreateEnemy(Transform at)
		{
			return _diContainer.InstantiatePrefabResource(PrefabsPaths.Enemy, at);
		}

		public GameObject CreateWeapon(GameObject prefab, Transform at)
			=> _diContainer.InstantiatePrefab(prefab, at);
	}
}