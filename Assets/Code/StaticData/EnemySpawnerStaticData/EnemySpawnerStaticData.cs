using Code.Data.Models.EnemySpawnerModel;
using UnityEngine;

namespace Code.StaticData.EnemySpawnerStaticData
{
	[CreateAssetMenu(fileName = "SpawnersStaticData", menuName = "EnemySpawnerStaticData", order = 4)]
	public class EnemySpawnerStaticData : ScriptableObject
	{
		public EnemySpawnerStats[] StartStats;
	}
}