using System;
using Code.Data.Models.GameModel;
using Code.Infrastructure.Factory;
using UnityEngine;
using VavilichevGD.Utils.Timing;
using Zenject;

namespace Code.Logic.Spawners
{
	public class EnemySpawner : MonoBehaviour
	{
		[SerializeField] private EnemySpawnerHealth enemySpawnerHealth;
		[SerializeField] private Transform spawnPoint;
		[SerializeField] private GameObject spawner;
		[SerializeField] private float timeToSpawnNext = 10;

		private IGameFactory _gameFactory;
		private IGameModel _gameModel;
		private bool _canSpawn;
		private float _timeToSpawnNext;

		[Inject]
		private void Construct(IGameFactory gameFactory, IGameModel gameModel)
		{
			_gameFactory = gameFactory;
			_gameModel = gameModel;
		}
		
		private void Awake()
		{
			spawner.SetActive(false);
			_canSpawn = false;
			_timeToSpawnNext = timeToSpawnNext;
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
			_gameFactory.CreateEnemy(spawnPoint);
			_timeToSpawnNext = timeToSpawnNext;
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
			_timeToSpawnNext = timeToSpawnNext;
			spawner.SetActive(true);
			enemySpawnerHealth.Refill();
			_gameModel.EnemySpawnerActivator.OnSpawnerActivated(this);
		}

		public void Deactivate()
		{
			_canSpawn = false;
			spawner.SetActive(false);
			_gameModel.EnemySpawnerActivator.OnSpawnerDeactivated(this);
		}
	}
}