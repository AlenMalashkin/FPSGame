using System.Collections;
using Code.Data.Models.GameModel;
using Code.Services.ArenaModeKillCounter;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Code.Enemy
{
	public class EnemyDeath : MonoBehaviour
	{
		[SerializeField] private EnemyAttack enemyAttack;
		[SerializeField] private NavMeshAgent agent;
		[SerializeField] private EnemyAnimator enemyAnimator;
		[SerializeField] private Collider[] enemyColliders;
		
		private IGameModel _gameModel;
		private IKillCounter _killCounter;
		
		[Inject]
		private void Construct(IGameModel gameModel, IKillCounter killCounter)
		{
			_gameModel = gameModel;
			_killCounter = killCounter;
		}

		public void Die()
		{
			enemyAnimator.PlayDie();
			_killCounter.AddKill();
			enemyAttack.enabled = false;
			agent.enabled = false;
			DisableAllColliders();
			_gameModel.RandomLootSpawner.SpawnRandomLoot(transform.position + new Vector3(0, 0.5f, 0));
			StartCoroutine(DestroyRoutine());
		}
		
		private IEnumerator DestroyRoutine()
		{
			yield return new WaitForSeconds(3);
			Destroy(gameObject);
		}

		private void DisableAllColliders()
		{
			foreach (var enemyCollider in enemyColliders)
			{
				enemyCollider.enabled = false;
			}
		}
	}
}