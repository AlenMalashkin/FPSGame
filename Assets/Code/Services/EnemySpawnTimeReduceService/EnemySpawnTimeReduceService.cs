using Code.Data.Models.EnemySpawnerModel;
using UnityEngine;
using VavilichevGD.Utils.Timing;

namespace Code.Services
{
	public class EnemySpawnTimeReduceService : IEnemySpawnTimeReduceService
	{
		private IEnemySpawnersModel _enemySpawnersModel;
		private SyncedTimer _timer;
		
		public EnemySpawnTimeReduceService(IEnemySpawnersModel enemySpawnersModel)
		{
			_enemySpawnersModel = enemySpawnersModel;
			_timer = new SyncedTimer(TimerType.UpdateTick);
		}

		public void StartReduce()
		{
			_timer.Start(_enemySpawnersModel.TimeToReduceSpawnTime);
			_timer.TimerFinished += ReduceSpawnTime;
		}

		public void StopReduce()
		{
			_timer.TimerFinished -= ReduceSpawnTime;
			_timer.Stop();
		}

		private void ReduceSpawnTime()
		{
			foreach (var enemySpawnerStats in _enemySpawnersModel.EnemySpawnersStats)
			{
				if (CanReduceSpawnTime(enemySpawnerStats.MinTimeToSpawnEnemy, enemySpawnerStats.TimeToSpawnEnemy))
				{
					enemySpawnerStats.TimeToSpawnEnemy -= 1;
					_timer.Start(_enemySpawnersModel.TimeToReduceSpawnTime);
				}
			}
		}

		private bool CanReduceSpawnTime(float minSpawnTime, float currentSpawnTime)
			=> currentSpawnTime > minSpawnTime;
	}
}