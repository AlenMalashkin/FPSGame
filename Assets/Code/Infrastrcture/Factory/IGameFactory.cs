using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject CreatePlayer(Transform at);
		GameObject CreateHud(Transform at);
		GameObject CreateEnemySpawner(Transform at);
		GameObject CreateEnemy(Transform at);
		GameObject CreateWeapon(GameObject prefab, Transform at);
	}
}