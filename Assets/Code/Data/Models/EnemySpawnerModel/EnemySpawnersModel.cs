using System.Collections.Generic;

namespace Code.Data.Models.EnemySpawnerModel
{
	public class EnemySpawnersModel : IEnemySpawnersModel
	{
		public float TimeToReduceSpawnTime { get; set; }
		public List<EnemySpawnerStats> EnemySpawnersStats { get; set; }

		public EnemySpawnersModel()
		{
			EnemySpawnersStats = new List<EnemySpawnerStats>();
		}
	}
}