using Code.Data.Models.GameModel;
using Code.Enemy;
using Code.Logic;
using Code.Logic.Spawners;
using Code.Services.StaticDataService;
using Code.StaticData.EnemyStaticData;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private DiContainer _diContainer;
		private IStaticDataService _staticDataService;
		private IGameModel _gameModel;
		
		[Inject]
		private void Construct(DiContainer diContainer, IStaticDataService staticDataService,
			IGameModel gameModel)
		{
			_diContainer = diContainer;
			_staticDataService = staticDataService;
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

		public GameObject CreateEnemySpawner(EnemyType type, Transform at)
		{
			GameObject enemySpawner = _diContainer.InstantiatePrefabResource(PrefabsPaths.EnemySpawnerPrefabPath, at.position, Quaternion.identity, at);
			enemySpawner.GetComponent<EnemySpawner>().Type = type;
			return enemySpawner;
		}

		public GameObject CreateEnemy(EnemyType type, Transform at)
		{
			EnemyStaticData enemyStaticData = _staticDataService.ForEnemy(type);
			GameObject enemy = _diContainer.InstantiatePrefab(enemyStaticData.EnemyPrefab, at);
			enemy.GetComponent<EnemyAttack>().Damage = enemyStaticData.Damage;
			enemy.GetComponent<IHealth>().MaxHealth = enemyStaticData.Health;
			enemy.GetComponent<IHealth>().CurrentHealth = enemyStaticData.Health;
			return enemy;
		}

		public GameObject CreateWeapon(GameObject prefab, Transform at)
			=> _diContainer.InstantiatePrefab(prefab, at);
	}
}