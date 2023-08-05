using System;
using Code.Data.Shop;
using Code.UI.Factory;
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
		
		[Inject]
		private void Construct(IUIFactory uiFactory)
		{
			_uiFactory = uiFactory;
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
			=> Destroy(gameObject);

		private void InitWeapons()
		{
			foreach (WeaponType weaponType in (WeaponType[]) Enum.GetValues(typeof(WeaponType)))
			{
				_uiFactory.CreateShopItem(shopItemPrefab, weaponsParent, weaponType);
			}
		}
	}
}