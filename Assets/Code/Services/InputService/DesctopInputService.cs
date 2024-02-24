using Code.Data.Models.GameModel;
using Code.UI.Elements.HUD;
using UnityEngine;

namespace Code.Services.InputService
{
	public class DesctopInputService : IInputService
	{
		private InputControlls _input;
		private IGameModel _gameModel;
		
		public DesctopInputService(InputControlls input, IGameModel gameModel)
		{
			_input = input;
			_gameModel = gameModel;
		}
		
		public void Enable()
			=> _input.Enable();

		public void Disable()
			=> _input.Disable();

		public Vector2 ReadMoveDirection()
			=> _input.Game.Move.ReadValue<Vector2>();

		public Vector2 ReadCameraRotation()
			=> _input.Game.MoveCamera.ReadValue<Vector2>();

		public bool ReadReloadButton()
			=> _input.Game.Reload.IsPressed();

		public bool ReadPauseButton()
			=> _input.Game.Pause.IsPressed();

		public bool ReadResumeButton()
			=> SimpleInput.GetButtonUp("Resume");

		public bool ReadBackToMenuButton()
			=> SimpleInput.GetButtonUp("BackToMenu");
	}
}