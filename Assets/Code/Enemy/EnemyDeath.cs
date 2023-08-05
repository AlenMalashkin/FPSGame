using Code.Data.Models.GameModel;
using UnityEngine;
using Zenject;

namespace Code.Enemy
{
	public class EnemyDeath : MonoBehaviour
	{
		private IGameModel _gameModel;
		
		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		public void Die()
		{
			_gameModel.RandomLootSpawner.SpawnRandomLoot(transform.position + new Vector3(0, 0.5f, 0));
			Destroy(gameObject);
		}
	}
}