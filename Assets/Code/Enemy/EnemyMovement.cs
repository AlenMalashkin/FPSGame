using Code.Data.Models.GameModel;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Code.Enemy
{
	public class EnemyMovement : MonoBehaviour
	{
		[SerializeField] private NavMeshAgent agent;

		private IGameModel _gameModel;
		private GameObject _player;
		
		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}

		private void Start()
		{
			_player = _gameModel.Player;
		}

		private void Update()
		{
			agent.SetDestination(_player.transform.position);
		}

		public void Stop()
		{
			agent.isStopped = true;
		}

		public void Move()
		{
			agent.isStopped = false;
		}
	}
}