using Code.Logic;
using Code.Logic.Loot;
using UnityEngine;

namespace Code.Player
{
	public class PlayerCollect : MonoBehaviour
	{
		[SerializeField] private TriggerObserver triggerObserver;

		private void OnEnable()
		{
			triggerObserver.TriggerEntered += OnTriggerEntered;
		}

		private void OnDisable()
		{
			triggerObserver.TriggerEntered += OnTriggerEntered;
		}

		private void OnTriggerEntered(Collider other)
		{
			if (other.TryGetComponent(out Loot loot))
				loot.Collect();
		}
	}
}