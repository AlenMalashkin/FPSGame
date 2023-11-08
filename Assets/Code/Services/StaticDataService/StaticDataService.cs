using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Data.Models.EnemySpawnerModel;
using Code.Data.Shop;
using Code.Enemy;
using Code.Logic;
using Code.Logic.GameModes;
using Code.StaticData;
using Code.StaticData.EnemySpawnerStaticData;
using Code.StaticData.EnemyStaticData;
using Code.StaticData.HUDConfigs;
using Code.StaticData.LevelStaticData;
using Code.StaticData.WeaponsConfig;
using Code.UI.Elements.HUD;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.StaticDataService
{
	public class StaticDataService : IStaticDataService
	{
		private Dictionary<GameModes, LevelStaticData> _levelsStaticDataMap = new Dictionary<GameModes, LevelStaticData>();
		private Dictionary<EnemyType, EnemyStaticData> _enemyStaticDataMap = new Dictionary<EnemyType, EnemyStaticData>();
		private Dictionary<WindowType, WindowConfig> _windowConfigsMap = new Dictionary<WindowType, WindowConfig>();
		private Dictionary<WeaponType, WeaponData> _weaponsData = new Dictionary<WeaponType, WeaponData>();
		private Dictionary<EnemyType, EnemySpawnerStats> _enemySpawnerStatsMap = new Dictionary<EnemyType, EnemySpawnerStats>();
		private Dictionary<HUDType, HUDConfig> _hudConfigsMap = new Dictionary<HUDType, HUDConfig>();
		
		public void Load()
		{
			_levelsStaticDataMap = Resources.LoadAll<LevelStaticData>(StaticDataPaths.LevelStaticDataPath)
				.ToDictionary(x => x.GameMode);
			
			_enemyStaticDataMap = Resources.LoadAll<EnemyStaticData>(StaticDataPaths.EnemyStaticDataPath)
				.ToDictionary(x => x.Type);
			
			_windowConfigsMap = Resources.Load<WindowConfigs>(StaticDataPaths.WindowConfigsPath)
				.Configs
				.ToDictionary(x => x.Type);

			_weaponsData = Resources.Load<WeaponsConfig>(StaticDataPaths.WeaponsConfigPath)
				.WeponsData
				.ToDictionary(x => x.Type);

			_enemySpawnerStatsMap = Resources.Load<EnemySpawnerStaticData>(StaticDataPaths.EnemySpawnersConfigPath)
				.StartStats
				.ToDictionary(x => x.Type);

			_hudConfigsMap = Resources.Load<HUDConfigs>(StaticDataPaths.HUDConfigsPath)
				.HUDConfigsList
				.ToDictionary(x => x.Type);
		}

		public LevelStaticData ForLevel(GameModes gameMode)
			=> _levelsStaticDataMap[gameMode];
		
		public EnemyStaticData ForEnemy(EnemyType type)
			=> _enemyStaticDataMap[type];

		public WindowConfig ForWindow(WindowType type)
			=> _windowConfigsMap[type];

		public WeaponData ForWeapon(WeaponType type)
			=> _weaponsData[type];

		public EnemySpawnerStats ForEnemySpawner(EnemyType type)
			=> _enemySpawnerStatsMap[type];

		public HUDConfig ForHud(HUDType type)
			=> _hudConfigsMap[type];
	}
}