using Code.Data;
using Code.Services.SaveService;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.StateMachine.States
{
	public class LoadProgressState : IState
	{
		private IGameStateMachine _gameStateMachine;
		private ISaveService _saveService;
		private IPersistentProgressModel _persistentProgress;
		
		public LoadProgressState(IGameStateMachine gameStateMachine, ISaveService saveService,
			IPersistentProgressModel persistentProgress)
		{
			_gameStateMachine = gameStateMachine;
			_saveService = saveService;
			_persistentProgress = persistentProgress;
		}
		
		public void Enter()
		{
			LoadProgressOrInitNew();
			_gameStateMachine.Enter<MenuState>();
		}

		public void Exit()
		{
		}

		private void LoadProgressOrInitNew()
		{
			_persistentProgress.Progress = _saveService.Load() ?? InitNewProgress();
		}

		private PlayerProgress InitNewProgress()
			=> new PlayerProgress();

		public class Factory : PlaceholderFactory<IGameStateMachine, LoadProgressState>
		{
		}
	}
}