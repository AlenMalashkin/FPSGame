using System.Threading.Tasks;
using Code.Enemy;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject CreatePlayer(Transform at);
		GameObject CreateHud(Transform at);
		GameObject CreateEnemySpawner(EnemyType type, Transform at);
		GameObject CreateEnemy(EnemyType type, Transform at);
		GameObject CreateWeapon(GameObject prefab, Transform at);
	}
}