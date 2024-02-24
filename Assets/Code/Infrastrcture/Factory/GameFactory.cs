using Code.Data;
using Code.Data.Models.EnemySpawnerModel;
using Code.Data.Models.GameModel;
using Code.Enemy;
using Code.Logic;
using Code.Logic.GameModes;
using Code.Logic.Loot;
using Code.Logic.Spawners;
using Code.Services.StaticDataService;
using Code.StaticData.EnemyStaticData;
using Code.StaticData.LevelStaticData;
using Code.StaticData.LootStaticData;
using Code.UI.Elements.HUD;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.Factory
{
	public class GameFactory : IGameFactory
	{
		private DiContainer _diContainer;
		private IStaticDataService _staticDataService;
		private IGameModel _gameModel;
		private IEnemySpawnersModel _enemySpawnersModel;
		
		[Inject]
		private void Construct(DiContainer diContainer, IStaticDataService staticDataService,
			IGameModel gameModel, IEnemySpawnersModel enemySpawnersModel)
		{
			_diContainer = diContainer;
			_staticDataService = staticDataService;
			_gameModel = gameModel;
			_enemySpawnersModel = enemySpawnersModel;
		}

		public GameObject CreateLevel(GameModes gameMode, Transform parent)
		{
			LevelStaticData levelStaticData = _staticDataService.ForLevel(gameMode);
			GameObject level = _diContainer.InstantiatePrefab(levelStaticData.LevelPrefab, parent);
			return level;
		}

		public GameObject CreatePlayer(Transform at)
		{
			GameObject player = _diContainer.InstantiatePrefabResource(PrefabsPaths.PlayerPrefabPath, at);
			_gameModel.Player = player;
			return player;
		}

		public GameObject CreateHud(Transform at, HUDType type)
		{
			HUDConfig hudConfig = _staticDataService.ForHud(type);
			_gameModel.HUD = _diContainer.InstantiatePrefabForComponent<HudBase>(hudConfig.HudPrefab, at);
			return _gameModel.HUD.gameObject;
		}

		public GameObject CreateEnemySpawner(EnemyType type, Transform at)
		{
			GameObject enemySpawner = _diContainer.InstantiatePrefabResource(PrefabsPaths.EnemySpawnerPrefabPath, at.position, Quaternion.identity, at);

			EnemySpawnerStats stats = _staticDataService.ForEnemySpawner(type);
			_enemySpawnersModel.TimeToReduceSpawnTime = 10;
			_enemySpawnersModel.EnemySpawnersStats.Add(stats);
			
			enemySpawner.GetComponent<EnemySpawner>().Stats = stats;
			enemySpawner.GetComponent<EnemySpawnerHealth>().Stats = stats;
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

		public GameObject CreateLoot(LootType type, Vector3 at, Transform parent)
		{
			LootStaticData lootStaticData = _staticDataService.ForLoot(type);
			
			return _diContainer.InstantiatePrefab(lootStaticData.LootPrefab, at, Quaternion.identity, parent);
		}

		public GameObject CreateWeapon(GameObject prefab, Transform at)
			=> _diContainer.InstantiatePrefab(prefab, at);
	}
}