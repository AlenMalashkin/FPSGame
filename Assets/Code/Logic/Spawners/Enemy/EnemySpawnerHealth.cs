using System;
using Code.Data.Models.EnemySpawnerModel;
using Code.Logic.Spawners;
using UnityEngine;

namespace Code.Logic
{
	public class EnemySpawnerHealth : MonoBehaviour, IHealth
	{
		public EnemySpawnerStats Stats { get; set; }

		[SerializeField] private EnemySpawner spawner;
		[SerializeField] private int currentHealth;
    
		public event Action<int> HealthChanged;
    
		public int MaxHealth 
		{ 
			get => Stats.EnemySpawnerHealth;
			set => Stats.EnemySpawnerHealth = value;
		}
    
		public int CurrentHealth 
		{ 
			get => currentHealth;
			set => currentHealth = value <= 0 ? 0 : value; 
		}

		private void Start()
		{
			currentHealth = Stats.EnemySpawnerHealth;
		}

		public void TakeDamage(int amount)
		{
			CurrentHealth -= amount;
			HealthChanged?.Invoke(CurrentHealth);

			if (CurrentHealth <= 0)
				Die();
		}

		public void Refill()
		{
			currentHealth = Stats.EnemySpawnerHealth;
			HealthChanged?.Invoke(CurrentHealth);
		}

		private void Die()
		{
			spawner.Deactivate();
		}
	}
}