using System.Threading.Tasks;
using Code.Enemy;
using Code.UI.Elements.HUD;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject CreatePlayer(Transform at);
		GameObject CreateHud(Transform at, HUDType type);
		GameObject CreateEnemySpawner(EnemyType type, Transform at);
		GameObject CreateEnemy(EnemyType type, Transform at);
		GameObject CreateWeapon(GameObject prefab, Transform at);
	}
}