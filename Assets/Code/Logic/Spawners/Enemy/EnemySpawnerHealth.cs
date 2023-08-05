using System;
using Code.Logic.Spawners;
using UnityEngine;

namespace Code.Logic
{
	public class EnemySpawnerHealth : MonoBehaviour, IHealth
	{
		[SerializeField] private EnemySpawner spawner;
		[SerializeField] private int maxHealth;
		[SerializeField] private int currentHealth;
    
		public event Action<int> HealthChanged;
    
		public int MaxHealth 
		{ 
			get => maxHealth;
			set => maxHealth = value;
		}
    
		public int CurrentHealth 
		{ 
			get => currentHealth;
			set => currentHealth = value <= 0 ? 0 : value; 
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
			currentHealth = maxHealth;
			HealthChanged?.Invoke(CurrentHealth);
		}

		private void Die()
		{
			spawner.Deactivate();
		}
	}
}