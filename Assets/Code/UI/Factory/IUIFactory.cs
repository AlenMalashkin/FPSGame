using Code.Data.Shop;
using Code.UI.Windows;
using Code.UI.Windows.ShopWindow;
using UnityEngine;

namespace Code.UI.Factory
{
	public interface IUIFactory
	{
		void CreateRoot(Transform parent);
		WindowBase CreateWindow(WindowType type);
		void CreateShopItem(ShopItem prefab, Transform parent, WeaponType type);
		RectTransform CreateCameraRotationZone();
	}
}