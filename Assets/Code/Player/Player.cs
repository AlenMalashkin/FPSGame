using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Services.InputService;
using Code.Services.PauseService;
using Code.UI.Elements.LoadingCurtain;
using UnityEngine;
using Zenject;

namespace Code.Player
{
	[RequireComponent(typeof(CharacterController))]
	public class Player : MonoBehaviour
	{
		private IInputService _inputService;
		private IPauseService _pauseService;
		private IGameStateMachine _gameStateMachine;
		private LoadingCurtain _loadingCurtain;

		[Inject]
		private void Construct(IInputService inputService, IPauseService pauseService, 
			IGameStateMachine gameStateMachine, LoadingCurtain loadingCurtain)
		{
			_inputService = inputService;
			_pauseService = pauseService;
			_gameStateMachine = gameStateMachine;
			_loadingCurtain = loadingCurtain;
		}
		
		private void OnEnable()
		{
			_inputService.Enable();
		}

		private void OnDisable()
		{
			_inputService.Disable();
		}

		private void Update()
		{
			if (_inputService.ReadPauseButton())
			{
				_pauseService.Pause(PauseType.PauseTimeScaleAndShowWindow);
			}

			if (_inputService.ReadResumeButton())
			{
				_pauseService.Unpause(PauseType.PauseTimeScaleAndShowWindow);
			}

			if (_inputService.ReadBackToMenuButton())
			{
				_pauseService.Unpause(PauseType.PauseTimeScaleAndShowWindow);
				_loadingCurtain.Show();
				_gameStateMachine.Enter<MenuState>();	
			}
		}
	}
}