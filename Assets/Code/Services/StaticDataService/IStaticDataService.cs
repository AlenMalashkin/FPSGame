using Code.Data;
using Code.Data.Shop;
using Code.StaticData;
using Code.UI.Windows;

namespace Code.Services.StaticDataService
{
	public interface IStaticDataService
	{
		void Load();
		WindowConfig ForWindow(WindowType type);
		WeaponData ForWeapon(WeaponType type);
	}
}