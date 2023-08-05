using System.Collections.Generic;
using System.Linq;
using Code.Data;
using Code.Data.Shop;
using Code.StaticData;
using Code.StaticData.WeaponsConfig;
using Code.UI.Windows;
using UnityEngine;

namespace Code.Services.StaticDataService
{
	public class StaticDataService : IStaticDataService
	{
		private Dictionary<WindowType, WindowConfig> _windowConfigsMap = new Dictionary<WindowType, WindowConfig>();
		private Dictionary<WeaponType, WeaponData> _weaponsData = new Dictionary<WeaponType, WeaponData>();
		
		public void Load()
		{
			_windowConfigsMap = Resources.Load<WindowConfigs>(StaticDataPaths.WindowConfigsPath)
				.Configs
				.ToDictionary(x => x.Type, x => x);

			_weaponsData = Resources.Load<WeaponsConfig>(StaticDataPaths.WeaponsConfigPath)
				.WeponsData
				.ToDictionary(x => x.Type, x => x);
		}

		public WindowConfig ForWindow(WindowType type)
			=> _windowConfigsMap[type];

		public WeaponData ForWeapon(WeaponType type)
			=> _weaponsData[type];
	}
}