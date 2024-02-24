using Code.Logic.Loot;
using Code.Logic.Spawners.Enemy;
using Code.UI.Elements.HUD;
using UnityEngine;

namespace Code.Data.Models.GameModel
{
	public class GameModel : IGameModel
	{
		public GameWorldInitializer GameWorldInitializer { get; set; }
		public GameObject Player { get; set; }
		public HudBase HUD { get; set; }
		public EnemySpawnerActivator EnemySpawnerActivator { get; set; }
		public RandomLootSpawner RandomLootSpawner { get; set; }
	}
}