using System;
using System.Collections.Generic;
using Code.Infrastructure.StateMachine.States;

namespace Code.Infrastructure.StateMachine
{
	public class GameStateMachine : IGameStateMachine
	{
		private IExitableState _currentState;
		private Dictionary<Type, IExitableState> _statesMap;

		public GameStateMachine(
			BootstrapState.Factory bootstrapStateFactory,
			LoadProgressState.Factory loadProgressStateFactory,
			MenuState.Factory menuStateFactory,
			GameState.Factory gameStateFactory,
			GameOverState.Factory gameOverStateFactory
			)
		{
			_statesMap = new Dictionary<Type, IExitableState>();
			
			RegisterState(bootstrapStateFactory.Create(this));
			RegisterState(loadProgressStateFactory.Create(this));
			RegisterState(menuStateFactory.Create(this));
			RegisterState(gameStateFactory.Create(this));
			RegisterState(gameOverStateFactory.Create(this));
		}

		private void RegisterState<TState>(TState state) where TState : class, IExitableState
			=> _statesMap.Add(typeof(TState), state);
		
		public void Enter<TState>() where TState : class, IState
		{
			IState state = ChangeState<TState>();
			state.Enter();
		}

		public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
		{
			TState state = GetState<TState>();
			state.Enter(payload);
		}

		private TState ChangeState<TState>() where TState : class, IExitableState
		{
			_currentState?.Exit();

			TState state = GetState<TState>();
			_currentState = state;

			return state;
		}

		private TState GetState<TState>() where TState : class, IExitableState
			=> _statesMap[typeof(TState)] as TState;
	}
}