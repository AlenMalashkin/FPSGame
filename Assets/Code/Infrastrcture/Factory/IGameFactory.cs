using System.Threading.Tasks;
using Code.Enemy;
using Code.Logic.GameModes;
using Code.UI.Elements.HUD;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
	public interface IGameFactory
	{
		GameObject CreateLevel(GameModes gameMode, Transform parent);
		GameObject CreatePlayer(Transform at);
		GameObject CreateHud(Transform at, HUDType type);
		GameObject CreateEnemySpawner(EnemyType type, Transform at);
		GameObject CreateEnemy(EnemyType type, Transform at);
		GameObject CreateWeapon(GameObject prefab, Transform at);
	}
}