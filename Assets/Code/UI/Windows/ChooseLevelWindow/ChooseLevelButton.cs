using System;
using Code.Infrastructure.StateMachine;
using Code.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI.Windows.ChooseLevelWindow
{
	public class ChooseLevelButton : MonoBehaviour
	{
		[SerializeField] private string levelName;
		[SerializeField] private Button enterLevelButton;
		
		private IGameStateMachine _gameStateMachine;
		
		[Inject]
		private void Construct(IGameStateMachine gameStateMachine)
		{
			_gameStateMachine = gameStateMachine;
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
			_gameStateMachine.Enter<GameState, string>(levelName);
		}
	}
}