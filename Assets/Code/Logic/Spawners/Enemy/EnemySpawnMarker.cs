using Code.Data.Models.GameModel;
using Code.Enemy;
using Code.Infrastructure.Factory;
using Code.Logic.GameWorld;
using Code.Logic.Spawners.Enemy;
using UnityEngine;
using Zenject;

namespace Code.Logic.Spawners
{
	public class EnemySpawnMarker : MonoBehaviour, IGameWorldPart
	{
		[SerializeField] private EnemyType type;
		
		private EnemySpawnerActivator _enemySpawnerActivator;
		
		private IGameFactory _gameFactory;
		private IGameModel _gameModel;
		
		[Inject]
		private void Construct(IGameFactory gameFactory, IGameModel gameModel)
		{
			_gameFactory = gameFactory;
			_gameModel = gameModel;
		}
		
		public void Initialize()
		{
			_enemySpawnerActivator = _gameModel.EnemySpawnerActivator;
			GameObject enemySpawner = _gameFactory.CreateEnemySpawner(type, transform);
			_enemySpawnerActivator.AllSpawners.Add(enemySpawner.GetComponent<EnemySpawner>());
		}
	}
}