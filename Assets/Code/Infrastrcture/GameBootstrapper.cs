using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
	public class GameBootstrapper : MonoBehaviour
	{
		private IGameStateMachine _gameStateMachine;

		[Inject]
		private void Construct(IGameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
		}
		
		private void Awake()
		{
			_gameStateMachine.Enter<BootstrapState>();
		}

		public class Factory : PlaceholderFactory<GameBootstrapper>
		{
		}
	}
}