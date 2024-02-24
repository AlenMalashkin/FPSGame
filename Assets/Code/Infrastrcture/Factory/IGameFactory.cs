using Code.Enemy;
using Code.Logic.GameModes;
using Code.Logic.Loot;
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
		GameObject CreateLoot(LootType type, Vector3 at, Transform parent);
		GameObject CreateWeapon(GameObject prefab, Transform at);
	}
}