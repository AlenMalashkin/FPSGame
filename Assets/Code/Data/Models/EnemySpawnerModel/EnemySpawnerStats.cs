using System;
using Code.Enemy;

namespace Code.Data.Models.EnemySpawnerModel
{
	[Serializable]
	public class EnemySpawnerStats
	{
		public EnemyType Type;
		public float TimeToSpawnEnemy;
		public int EnemySpawnerHealth;

		public EnemySpawnerStats(EnemyType type, float timeToSpawnEnemy, int enemySpawnerHealth)
		{
			Type = type;
			TimeToSpawnEnemy = timeToSpawnEnemy;
		}
	}
}