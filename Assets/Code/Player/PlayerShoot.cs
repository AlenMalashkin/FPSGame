using System;
using Code.Data;
using Code.Data.Shop;
using Code.Infrastructure.Factory;
using Code.Logic;
using Code.Services.StaticDataService;
using UnityEngine;
using VavilichevGD.Utils.Timing;
using Zenject;

namespace Code.Player
{
	public class PlayerShoot : MonoBehaviour
    {
        public event Action Shooted;
        
        [Header("References")] 
        [SerializeField] private PlayerReload playerReload;
        
        [Header("Camera")] 
        [SerializeField] private Camera firstPersonCamera;
        
        [Header("Weapon")] 
        [SerializeField] private Transform weaponSpawnPoint;
        [SerializeField] private int damage = 10;

        [Header("Ray")]
        [SerializeField] private LayerMask layerMask;
        [SerializeField] private float distance = Mathf.Infinity;

        private PlayerInput _playerInput;
        private IGameFactory _gameFactory;
        private IPersistentProgressModel _persistentProgress;
        private IStaticDataService _staticData;

        [Inject]
        private void Construct(IGameFactory gameFactory, IPersistentProgressModel persistentProgress, IStaticDataService staticData)
        {
            _gameFactory = gameFactory;
            _persistentProgress = persistentProgress;
            _staticData = staticData;
        }
        
        private void Start()
        {
            _playerInput = GetComponent<PlayerInput>();
            WeaponData weaponData = _staticData.ForWeapon(_persistentProgress.Progress.WeaponEquipped);
            damage = weaponData.Damage;
            _gameFactory.CreateWeapon(weaponData.weaponPrefab, weaponSpawnPoint);
        }

        private void Update()
        {
            if (_playerInput.InputService.InputControlls.Game.Shoot.IsPressed())
            {
                TryShoot();
            }
        }

        private void TryShoot()
        {
            if (playerReload.CanShoot())
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            var direction = firstPersonCamera.transform.forward;
            var ray = new Ray(firstPersonCamera.transform.position, direction);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, distance, layerMask))
            {
                var hitCollider = hitInfo.collider;

                if (hitCollider.gameObject.TryGetComponent(out IHealth damageable))
                {
                    damageable.TakeDamage(damage);
                }
            }
            
            Shooted?.Invoke();
        }
    }
}