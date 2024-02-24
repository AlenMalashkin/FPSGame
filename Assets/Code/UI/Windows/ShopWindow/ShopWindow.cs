using System;
using System.Collections.Generic;
using System.Linq;
using Code.Data.Shop;
using Code.UI.Factory;
using Code.UI.Services;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.ShopWindow
{
	public class ShopWindow : WindowBase
	{
		[SerializeField] private Button closeButton;
		[SerializeField] private ShopItem shopItemPrefab;
		[SerializeField] private Transform weaponsParent;

		private IUIFactory _uiFactory;
		private IWindowService _windowService;
		
		[Inject]
		private void Construct(IUIFactory uiFactory, IWindowService windowService)
		{
			_uiFactory = uiFactory;
			_windowService = windowService;
		}
		
		private void Awake()
		{
			InitWeapons();
		}

		private void OnEnable()
		{
			closeButton.onClick.AddListener(Close);
		}

		private void OnDisable()
		{
			closeButton.onClick.RemoveListener(Close);
		}

		private void Close()
			=> _windowService.Close(WindowType.Shop);

		private void InitWeapons()
		{
			foreach (var weapon in (WeaponType[]) Enum.GetValues(typeof(WeaponType)))
			{
				_uiFactory.CreateShopItem(shopItemPrefab, weaponsParent, weapon);
			}
		}
	}
}