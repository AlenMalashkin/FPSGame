using Code.Logic;
using UnityEngine;
using UnityEngine.UI;

namespace Code.UI.Elements.HPBar
{
	public class HpBar : MonoBehaviour
	{
		[SerializeField] private Image healthBar;
		
		private IHealth _health;
		
		public void Construct(IHealth health)
		{
			_health = health;
			_health.HealthChanged += OnHealthChanged;
		}
		
		private void Awake()
		{
			if (_health != null)
				return;
			
			_health = GetComponent<IHealth>();
			_health.HealthChanged += OnHealthChanged;
		}

		private void OnDestroy()
		{
			_health.HealthChanged -= OnHealthChanged;
		}

		private void SetValue(int currentHealth, int maxHealth)
		{
			healthBar.fillAmount = (float) currentHealth / maxHealth;
		}

		private void OnHealthChanged(int currentHealth)
		{
			SetValue(currentHealth, _health.MaxHealth);
		}
	}
}