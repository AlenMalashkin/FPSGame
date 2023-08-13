using System.Collections.Generic;
using Code.Enemy;

namespace Code.Data.Models.EnemySpawnerModel
{
	public interface IEnemySpawnersModel
	{
		float TimeToReduceSpawnTime { get; set; }
		List<EnemySpawnerStats> EnemySpawnersStats { get; set; }
	}
}