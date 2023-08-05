using Code.Data;
using Code.Data.Shop;
using Code.Services.Bank;
using Code.Services.SaveService;
using Code.Services.StaticDataService;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.ShopWindow
{
	public class ShopItem : MonoBehaviour
	{
		public WeaponType Type { get; set; }
		[SerializeField] private Button buyOrEquip;
		[SerializeField] private Image itemIcon;
		[SerializeField] private TextMeshProUGUI itemText;

		private IStaticDataService _staticDataService;
		private IPersistentProgressModel _persistentProgress;
		private ISaveService _saveService;
		private IBank _bank;
		private WeaponData _weaponData;
		
		[Inject]
		private void Construct(IStaticDataService staticDataService, IPersistentProgressModel persistentProgress,
			ISaveService saveService, IBank bank)
		{
			_staticDataService = staticDataService;
			_persistentProgress = persistentProgress;
			_saveService = saveService;
			_bank = bank;
		}

		public void Init()
		{
			_weaponData = _staticDataService.ForWeapon(Type);
			itemIcon.sprite = _weaponData.Sprite;
			buyOrEquip.onClick.AddListener(BuyOrEquip);
			_saveService.ProgressSaved += UpdateUI;
			UpdateUI();
		}

		private void OnDestroy()
		{
			_saveService.ProgressSaved -= UpdateUI;
		}

		private void BuyOrEquip()
		{
			Buy();
			Equip();
			_saveService.Save();
		}

		private void Buy()
		{
			if (!CheckIsBought() && _bank.SpendMoney(_weaponData.Cost))
			{
				_persistentProgress.Progress.WeaponsBought.Add(Type);
				itemText.text = "Куплено";
			}
		}

		private void Equip()
		{
			if (CheckIsBought() && !CheckIsEquipped())
			{
				_persistentProgress.Progress.WeaponEquipped = Type;
				itemText.text = "Выбрано";
				buyOrEquip.interactable = false;
			}
		}

		private bool CheckIsBought()
			=> _persistentProgress.Progress.WeaponsBought.Contains(Type);

		private bool CheckIsEquipped()
			=> _persistentProgress.Progress.WeaponEquipped == Type;

		private void UpdateUI()
		{
			if (CheckIsBought() && !CheckIsEquipped())
			{
				itemText.text = "Куплено";
				buyOrEquip.interactable = true;
			}
			else if (CheckIsBought() && CheckIsEquipped())
			{
				itemText.text = "Выбрано";
				buyOrEquip.interactable = false;
			}
			else
			{
				itemText.text = _weaponData.Cost + "";
			}
		}
	}
}