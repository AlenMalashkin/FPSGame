using System.Collections;
using Code.Data.Models.GameModel;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
	public class EnemyDeath : MonoBehaviour
	{
		[SerializeField] private EnemyMovement enemyMovement;
		[SerializeField] private EnemyAnimator enemyAnimator;
		[SerializeField] private Collider[] enemyColliders;
		
		private IGameModel _gameModel;
		
		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		public void Die()
		{
			enemyAnimator.PlayDie();
			enemyMovement.Stop();
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