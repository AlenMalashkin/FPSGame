using Code.Data.Models.EnemySpawnerModel;
using Code.Data.Models.GameModel;
using Code.Infrastructure.Factory;
using UnityEngine;
using Zenject;

namespace Code.Logic.Spawners
{
	public class EnemySpawner : MonoBehaviour
	{
		public EnemySpawnerStats Stats { get; set; }

		[SerializeField] private EnemySpawnerHealth enemySpawnerHealth;
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private GameObject spawner;
		[SerializeField] private Collider spawnerCollider;

		private IGameFactory _gameFactory;
		private IGameModel _gameModel;
		private float _timeToSpawnNext;
		private bool _canSpawn;

		[Inject]
		private void Construct(IGameFactory gameFactory, IGameModel gameModel)
		{
			_gameFactory = gameFactory;
			_gameModel = gameModel;
		}
		
		private void Start()
		{
			spawner.SetActive(false);
			spawnerCollider.enabled = false;
			_canSpawn = false;
			_timeToSpawnNext = Stats.TimeToSpawnEnemy;
		}

		private void Update()
		{
			CountCooldown();

			if (CooldownIsUp())
			{
				Spawn();
			}
		}

		private void Spawn()
		{
			_gameFactory.CreateEnemy(Stats.Type, spawnPoint);
			_timeToSpawnNext = Stats.TimeToSpawnEnemy;
		}

		private void CountCooldown()
		{ 
			if (_canSpawn)
				_timeToSpawnNext -= Time.deltaTime;
		}

		private bool CooldownIsUp()
			=> _timeToSpawnNext <= 0;

		public void Activate()
		{
			_canSpawn = true;
			_timeToSpawnNext = Stats.TimeToSpawnEnemy;
			spawner.SetActive(true);
			spawnerCollider.enabled = true;
			enemySpawnerHealth.Refill();
			_gameModel.EnemySpawnerActivator.OnSpawnerActivated(this);
			Spawn();
		}

		public void Deactivate()
		{
			_canSpawn = false;
			spawner.SetActive(false);
			spawnerCollider.enabled = false;
			_gameModel.EnemySpawnerActivator.OnSpawnerDeactivated(this);
		}
	}
}