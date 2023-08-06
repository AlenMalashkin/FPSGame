using System;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Logic;
using Code.Services.GameOverService;
using UnityEngine;
using Zenject;

namespace Code.Player
{
	public class PlayerHealth : MonoBehaviour, IHealth
	{
		[SerializeField] private int maxHealth;
		[SerializeField] private int currentHealth;

		private IGameOverService _gameOverService;
		
		[Inject]
		private void Construct(IGameOverService gameOverService)
		{
			_gameOverService = gameOverService;
		}
		
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
		    _gameOverService.OverGameWithResult(GameResults.Lose);
	    }

	    public void CollectHealth()
	    {
		    CurrentHealth += 25;
		    HealthChanged?.Invoke(CurrentHealth);
	    }
    }
}

