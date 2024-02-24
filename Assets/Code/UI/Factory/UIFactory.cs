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

		public WindowBase CreateWindow(WindowType type)
		{
			WindowConfig windowConfig = _staticDataService.ForWindow(type);
			return _diContainer.InstantiatePrefabForComponent<WindowBase>(windowConfig.WindowPrefab, _uiRoot);
		}

		public void CreateShopItem(ShopItem prefab, Transform parent, WeaponType type)
		{
			ShopItem shopItem = _diContainer.InstantiatePrefabForComponent<ShopItem>(prefab, parent);
			shopItem.Type = type;
			shopItem.Init();
		}

		public RectTransform CreateCameraRotationZone()
		{
			return _diContainer.InstantiatePrefabResourceForComponent<RectTransform>("UI/CameraRotationZone", _uiRoot);
		}
	}
}