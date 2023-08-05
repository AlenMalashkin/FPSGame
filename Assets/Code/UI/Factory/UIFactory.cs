using Code.Data;
using Code.Data.Shop;
using Code.Services.StaticDataService;
using Code.UI.Windows;
using Code.UI.Windows.ShopWindow;
using UnityEngine;
using Zenject;

namespace Code.UI.Factory
{
	public class UIFactory : IUIFactory
	{
		private Transform _uiRoot;
		private IStaticDataService _staticDataService;
		private DiContainer _diContainer;
		
		public UIFactory(IStaticDataService staticDataService, DiContainer diContainer)
		{
			_staticDataService = staticDataService;
			_diContainer = diContainer;
		}
		
		public void CreateRoot(Transform parent)
		{
			GameObject uiRoot = _diContainer.InstantiatePrefabResource("UI/UIRoot", parent);
			_uiRoot = uiRoot.transform;
		}

		public void CreateMenu()
		{
			WindowConfig menuWindowConfig = _staticDataService.ForWindow(WindowType.Menu);
			_diContainer.InstantiatePrefab(menuWindowConfig.WindowPrefab, _uiRoot);
		}

		public void CreateShop()
		{
			WindowConfig shopWindowConfig = _staticDataService.ForWindow(WindowType.Shop);
			_diContainer.InstantiatePrefab(shopWindowConfig.WindowPrefab, _uiRoot);
		}

		public void CreateChooseLevel()
		{
			WindowConfig chooseLevelWindowConfig = _staticDataService.ForWindow(WindowType.ChooseLevel);
			_diContainer.InstantiatePrefab(chooseLevelWindowConfig.WindowPrefab, _uiRoot);
		}

		public void CreateShopItem(ShopItem prefab, Transform parent, WeaponType type)
		{
			ShopItem shopItem = _diContainer.InstantiatePrefab(prefab, parent).GetComponent<ShopItem>();
			shopItem.Type = type;
			shopItem.Init();
		}
	}
}