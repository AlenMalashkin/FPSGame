using System;

namespace Code.Logic
{
	public interface IHealth
	{
		event Action<int> HealthChanged; 
		int MaxHealth { get; set; }
		int CurrentHealth { get; set; }
		void TakeDamage(int amount);
	}
}