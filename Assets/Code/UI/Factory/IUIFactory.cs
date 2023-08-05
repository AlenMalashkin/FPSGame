using Code.Data.Shop;
using Code.UI.Windows.ShopWindow;
using UnityEngine;

namespace Code.UI.Factory
{
	public interface IUIFactory
	{
		void CreateRoot(Transform parent);
		void CreateMenu();
		void CreateShop();
		void CreateChooseLevel();
		void CreateShopItem(ShopItem prefab, Transform parent, WeaponType type);
	}
}