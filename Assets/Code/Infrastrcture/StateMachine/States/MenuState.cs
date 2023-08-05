using Code.UI.Elements.LoadingCurtain;
using Code.UI.Factory;
using Code.UI.Services;
using Code.UI.Windows;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure.StateMachine.States
{
	public class MenuState : IState
	{
		private const string MenuSceneName = "Menu";

		private IGameStateMachine _gameStateMachine;
		private SceneLoader _sceneLoader;
		private LoadingCurtain _curtain;
		private IWindowService _windowService;
		private DiContainer _diContainer;
		
		public MenuState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader,
			LoadingCurtain curtain, IWindowService windowService)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_curtain = curtain;
			_windowService = windowService;
		}
		
		public void Enter()
		{
			_sceneLoader.Load(MenuSceneName, OnLoad);
		}

		public void Exit()
		{
		}

		private void OnLoad()
		{
			_curtain.Hide();
			_windowService.Open(WindowType.Menu);
		}

		public class Factory : PlaceholderFactory<IGameStateMachine, MenuState>
		{
		}
	}
}