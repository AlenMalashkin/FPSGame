using Code.Services.GameOverService;
using Code.Services.InputService;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Zenject;

namespace Code.Player
{
	public class PlayerInput : MonoBehaviour
	{
		public IInputService InputService { get; private set; }
		private IGameOverService _gameOverService;

		[Inject]
		private void Construct(IInputService inputService, IGameOverService gameOverService)
		{
			InputService = inputService;
			_gameOverService = gameOverService;
		}

		private void OnEnable()
		{
			InputService.Enable();
			_gameOverService.ResultsReported += OnResultsReported;
		}

		private void OnDisable()
		{
			InputService.Disable();
			_gameOverService.ResultsReported -= OnResultsReported;
		}

		private void OnResultsReported(GameResults results)
		{
			Debug.Log("Results reported");
			InputService.Disable();
		}

		public Vector2 ReadMoveDirection()
		{
			Vector2 moveDirection = new Vector2(
				InputService.InputControlls.Game.Move.ReadValue<Vector2>().x,
				InputService.InputControlls.Game.Move.ReadValue<Vector2>().y);

			return moveDirection;
		}

		public Vector2 ReadMouseDelta()
		{
			Vector2 axis = new Vector2(
				InputService.InputControlls.Game.MoveCamera.ReadValue<Vector2>().x,
				InputService.InputControlls.Game.MoveCamera.ReadValue<Vector2>().y
				);

			return axis;
		}
	}
}