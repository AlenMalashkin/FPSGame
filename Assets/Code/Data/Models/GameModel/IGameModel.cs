using Code.Logic.Loot;
using Code.Logic.Spawners.Enemy;
using Code.UI.Elements.HUD;
using UnityEngine;

namespace Code.Data.Models.GameModel
{
	public interface IGameModel
	{
		GameWorldInitializer GameWorldInitializer { get; set; }
		GameObject Player { get; set; }
		HudBase HUD { get; set; }
		EnemySpawnerActivator EnemySpawnerActivator { get; set; }
		RandomLootSpawner RandomLootSpawner { get; set; }
	}
}