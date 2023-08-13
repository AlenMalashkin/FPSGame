using Code.Data;
using Code.Data.Models.EnemySpawnerModel;
using Code.Data.Shop;
using Code.Enemy;
using Code.StaticData.EnemySpawnerStaticData;
using Code.StaticData.EnemyStaticData;
using Code.UI.Elements.HUD;
using Code.UI.Windows;

namespace Code.Services.StaticDataService
{
	public interface IStaticDataService
	{
		void Load();
		EnemyStaticData ForEnemy(EnemyType type);
		WindowConfig ForWindow(WindowType type);
		WeaponData ForWeapon(WeaponType type);
		EnemySpawnerStats ForEnemySpawner(EnemyType type);
		HUDConfig ForHud(HUDType type);
	}
}