using System;
using Code.Logic;
using UnityEngine;

namespace Code.Enemy
{
	public class CheckAttackRange : MonoBehaviour
	{
		[SerializeField] private TriggerObserver triggerObserver;
		[SerializeField] private EnemyAttack enemyAttack;

		private void OnEnable()
		{
			triggerObserver.TriggerEntered += OnTriggerEntered;
			triggerObserver.TriggerExited += OnTriggerExited;
		}

		private void OnDisable()
		{
			triggerObserver.TriggerEntered -= OnTriggerEntered;
			triggerObserver.TriggerExited -= OnTriggerExited;
		}

		private void OnTriggerEntered(Collider other)
		{
			enemyAttack.EnableAttack();
		}
		
		private void OnTriggerExited(Collider other)
		{
			enemyAttack.DisableAttack();
		}
	}
}