using System;
using Code.Data;
using Code.Data.Shop;
using Code.Services.InputService;
using Code.Services.StaticDataService;
using UnityEngine;
using VavilichevGD.Utils.Timing;
using Zenject;

namespace Code.Player
{
	public class PlayerReload : MonoBehaviour
	{
		public event Action<int, int> BulletsCountChanged;
		
		[Header("References")] 
		[SerializeField] private PlayerShoot playerShoot;
		
		[Header("Weapon")]
		[SerializeField] private float reloadTime;
		[SerializeField] private float fireRate;
		[SerializeField] private int bulletsInBagMax;
		[SerializeField] private int bulletsInBag;
		[SerializeField] private int bulletsInClipMax;
		[SerializeField] private int bulletsInClipCurrent;

		private IProgressModel _progress;
		private IStaticDataService _staticData;
		private IInputService _inputService;
		private SyncedTimer _reloadTimer;
		private SyncedTimer _fireRateTimer;
		private bool _isReloading;
		private bool _isEmptyClip;
		
		[Inject]
		private void Construct(IProgressModel progress, IStaticDataService staticData,
			 IInputService inputService)
		{
			_progress = progress;
			_staticData = staticData;
			_inputService = inputService;
		}

		private void Awake()
		{
			_reloadTimer = new SyncedTimer(TimerType.UpdateTick);
			_fireRateTimer = new SyncedTimer(TimerType.UpdateTick);
			
			WeaponData weaponData = _staticData.ForWeapon(_progress.Progress.WeaponEquipped);
			reloadTime = weaponData.ReloadTime;
			fireRate = weaponData.FireRate;
			bulletsInBagMax = weaponData.BulletsCount;
			bulletsInBag = weaponData.BulletsCount;
			bulletsInClipMax = weaponData.BulletsInClip;
			bulletsInClipCurrent = weaponData.BulletsInClip;
		}

		private void Start()
		{
			BulletsCountChanged?.Invoke(bulletsInClipCurrent, bulletsInBag);
		}

		private void Update()
		{
			if (_inputService.ReadReloadButton())
			{
				Reload();
			}
		}

		private void OnEnable()
		{
			playerShoot.Shooted += OnShooted;
			_reloadTimer.TimerFinished += ReloadCompleted;
		}

		private void OnDisable()
		{
			playerShoot.Shooted -= OnShooted;
			_reloadTimer.TimerFinished -= ReloadCompleted;
		}

		private void OnShooted()
		{
			bulletsInClipCurrent -= 1;
			_fireRateTimer.Start(fireRate);
			
			if (CheckIsClipEmpty())
				Reload();
			
			BulletsCountChanged?.Invoke(bulletsInClipCurrent, bulletsInBag);
		}

		private void Reload()
		{
			if (bulletsInClipCurrent != bulletsInClipMax)
			{
				_reloadTimer.Start(reloadTime); 
				_isReloading = true;
			}
		}

		private bool TryReloadFullClip()
		{
			if (bulletsInBag >= bulletsInClipMax - bulletsInClipCurrent)
			{
				bulletsInBag -= bulletsInClipMax - bulletsInClipCurrent;
				bulletsInClipCurrent = bulletsInClipMax;
				return true;
			}

			return false;
		}

		private void ReloadRemainFromBag()
		{
			bulletsInClipCurrent += bulletsInBag;
			bulletsInBag -= bulletsInBag;
		}

		private void ReloadCompleted()
		{
			if (!TryReloadFullClip())
				ReloadRemainFromBag();

			_isReloading = false;
			
			BulletsCountChanged?.Invoke(bulletsInClipCurrent, bulletsInBag);
		}

		private bool CheckFireRate()
			=> _fireRateTimer.remainingSeconds <= 0;

		private bool CheckIsClipEmpty()
			=> bulletsInClipCurrent <= 0;

		public void CollectBullets()
		{
			bulletsInBag += bulletsInClipMax;

			if (bulletsInBag > bulletsInBagMax)
				bulletsInBag = bulletsInBagMax;
			
			BulletsCountChanged?.Invoke(bulletsInClipCurrent, bulletsInBag);
		}

		public bool CanShoot()
			=> !_isReloading && !CheckIsClipEmpty() && CheckFireRate();
	}
}