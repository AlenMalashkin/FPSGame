using System;
using Code.Logic;
using UnityEngine;

namespace Code.Player
{
	public class PlayerHealth : MonoBehaviour, IHealth
	{
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
		    set
		    {
			    currentHealth = value <= 0 ? 0 : value;

			    if (currentHealth > MaxHealth)
				    currentHealth = MaxHealth;
		    }
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
	    }

	    public void CollectHealth()
	    {
		    CurrentHealth += 25;
		    HealthChanged?.Invoke(CurrentHealth);
	    }
    }
}

