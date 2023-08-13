using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using Code.Logic.GameModes;
using Code.Services.ChooseGameModeService;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.ChooseLevelWindow
{
	public class ChooseLevelButton : MonoBehaviour
	{
		[SerializeField] private GameModes gameMode;
		[SerializeField] private string levelName;
		[SerializeField] private Button enterLevelButton;
		
		private IGameStateMachine _gameStateMachine;
		private IChooseGameModeService _chooseGameModeService;
		
		[Inject]
		private void Construct(IGameStateMachine gameStateMachine, IChooseGameModeService chooseGameModeService)
		{
			_gameStateMachine = gameStateMachine;
			_chooseGameModeService = chooseGameModeService;
		}

		private void OnEnable()
		{
			enterLevelButton.onClick.AddListener(EnterLevel);
		}

		private void OnDisable()
		{
			enterLevelButton.onClick.AddListener(EnterLevel);
		}

		private void EnterLevel()
		{
			_chooseGameModeService.ChooseGameMode(gameMode);
			_gameStateMachine.Enter<GameState, string>(levelName);
		}
	}
}