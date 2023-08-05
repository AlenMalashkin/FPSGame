using System;
using System.Collections.Generic;
using Code.Data.Models.GameModel;
using Code.Logic.GameWorld;
using UnityEngine;
using VavilichevGD.Utils.Timing;
using Zenject;
using Random = UnityEngine.Random;

namespace Code.Logic.Spawners.Enemy
{
	public class EnemySpawnerActivator : MonoBehaviour, IGameWorldPart
	{
		public List<EnemySpawner> AllSpawners { get; } = new List<EnemySpawner>();

		[SerializeField] private float timeToActivate;

		private List<EnemySpawner> _activeSpawners = new List<EnemySpawner>();
		private List<EnemySpawner> _deactivatedSpawners = new List<EnemySpawner>();
		private SyncedTimer _timer;
		private IGameModel _gameModel;

		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		private void OnDestroy()
		{
			if (_timer != null)
				_timer.TimerFinished -= ActivateRandomSpawner;
		}

		public void Initialize()
		{
			_gameModel.EnemySpawnerActivator = this;
			_deactivatedSpawners = AllSpawners;
			_timer = new SyncedTimer(TimerType.UpdateTick);
			_timer.Start(timeToActivate);
			_timer.TimerFinished += ActivateRandomSpawner;
		}

		private void ActivateRandomSpawner()
		{
			if (_deactivatedSpawners.Count != 0) 
				_deactivatedSpawners[Random.Range(0, _deactivatedSpawners.Count)].Activate();
		}

		public void OnSpawnerActivated(EnemySpawner spawner)
		{
			_deactivatedSpawners.Remove(spawner);
			_activeSpawners.Add(spawner);
			_timer.Start(timeToActivate);
		}

		public void OnSpawnerDeactivated(EnemySpawner spawner)
		{
			_activeSpawners.Remove(spawner);
			_deactivatedSpawners.Add(spawner);
			_timer.Start(timeToActivate);
		}
	}
}