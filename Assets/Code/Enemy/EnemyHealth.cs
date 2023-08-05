using System;
using Code.Logic;
using UnityEngine;

namespace Code.Enemy
{
	public class EnemyHealth : MonoBehaviour, IHealth
	{
		public event Action<int> HealthChanged;

		[SerializeField] private EnemyDeath enemyDeath;
		[SerializeField] private int maxHealth;
		[SerializeField] private int currentHealth;

		public int MaxHealth
		{
			get => maxHealth; 
			set => maxHealth = value;
		}

		public int CurrentHealth
		{
			get => currentHealth; 
			set => currentHealth = value >= 0 ? value : 0;
		}

		public void TakeDamage(int amount)
		{
			CurrentHealth -= amount;
			HealthChanged?.Invoke(CurrentHealth);

			if (CurrentHealth <= 0)
				Die();
		}

		private void Die()
		{
			enemyDeath.Die();
		}
	}
}