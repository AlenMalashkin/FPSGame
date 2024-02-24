using Audio;
using Code.UI.Elements.LoadingCurtain;
using Code.UI.Services;
using Code.UI.Windows;
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
		private MusicPlayer _musicPlayer;
		
		public MenuState(IGameStateMachine gameStateMachine, SceneLoader sceneLoader,
			LoadingCurtain curtain, IWindowService windowService, MusicPlayer musicPlayer)
		{
			_gameStateMachine = gameStateMachine;
			_sceneLoader = sceneLoader;
			_curtain = curtain;
			_windowService = windowService;
			_musicPlayer = musicPlayer;
		}
		
		public void Enter()
		{
			_sceneLoader.Load(MenuSceneName, OnLoad);
		}

		public void Exit()
		{
			_windowService.CloseAllOpenedWindows();
		}

		private void OnLoad()
		{
			_curtain.Hide();
			_windowService.Open(WindowType.Menu);
			_musicPlayer.PlayLoopedAudio("MenuBgMusic");	
		}

		public class Factory : PlaceholderFactory<IGameStateMachine, MenuState>
		{
		}
	}
}