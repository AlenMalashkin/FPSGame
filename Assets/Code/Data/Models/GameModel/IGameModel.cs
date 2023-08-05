using Code.Logic.Loot;
using Code.Logic.Spawners.Enemy;
using UnityEngine;

namespace Code.Data.Models.GameModel
{
	public interface IGameModel
	{
		GameWorldInitializer GameWorldInitializer { get; set; }
		GameObject Player { get; set; }
		EnemySpawnerActivator EnemySpawnerActivator { get; set; }
		RandomLootSpawner RandomLootSpawner { get; set; }
	}
}