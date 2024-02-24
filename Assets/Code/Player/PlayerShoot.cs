using System;
using Code.Data;
using Code.Data.Shop;
using Code.Infrastructure.Factory;
using Code.Logic;
using Code.Logic.Weapons;
using Code.Services.StaticDataService;
using UnityEngine;
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

        private IGameFactory _gameFactory;
        private IProgressModel _progress;
        private IStaticDataService _staticData;

        private Weapon _weapon;

        [Inject]
        private void Construct(IGameFactory gameFactory, IProgressModel progress, 
            IStaticDataService staticData)
        {
            _gameFactory = gameFactory;
            _progress = progress;
            _staticData = staticData;
        }
        
        private void Start()
        {
            WeaponData weaponData = _staticData.ForWeapon(_progress.Progress.WeaponEquipped);
            damage = weaponData.Damage;
            GameObject weapon = _gameFactory.CreateWeapon(weaponData.weaponPrefab, weaponSpawnPoint);
            _weapon = weapon.GetComponent<Weapon>();
        }

        private void Update()
        {
            Shoot();
        }

        private void Shoot()
        {
            var direction = firstPersonCamera.transform.forward;
            var ray = new Ray(firstPersonCamera.transform.position, direction);
            Debug.DrawRay(ray.origin, direction * 200, Color.red, 1);
            
            if (Physics.Raycast(ray, out RaycastHit hitInfo, distance, layerMask) 
                && hitInfo.collider.TryGetComponent(out IHealth damageable)
                && playerReload.CanShoot())
            {
                damageable.TakeDamage(damage);
                
                _weapon.NotifyShoot();
            
                Shooted?.Invoke();
            }
        }
    }
}