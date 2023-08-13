using System;
using Code.Enemy;

namespace Code.Data.Models.EnemySpawnerModel
{
	[Serializable]
	public class EnemySpawnerStats
	{
		public EnemyType Type;
		public float TimeToSpawnEnemy;
		public float MinTimeToSpawnEnemy;
		public int EnemySpawnerHealth;

		public EnemySpawnerStats(EnemyType type, float timeToSpawnEnemy, float minTimeToSpawnEnemy, int enemySpawnerHealth)
		{
			Type = type;
			TimeToSpawnEnemy = timeToSpawnEnemy;
			MinTimeToSpawnEnemy = minTimeToSpawnEnemy;
			EnemySpawnerHealth = enemySpawnerHealth;
		}
	}
}