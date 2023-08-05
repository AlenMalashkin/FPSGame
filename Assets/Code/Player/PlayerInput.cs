using Code.Services.InputService;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using Zenject;

namespace Code.Player
{
	public class PlayerInput : MonoBehaviour
	{
		public IInputService InputService { get; private set; }

		[Inject]
		private void Construct(IInputService inputService)
		{
			InputService = inputService;
		}

		private void OnEnable()
		{
			InputService.Enable();
		}

		private void OnDisable()
		{
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