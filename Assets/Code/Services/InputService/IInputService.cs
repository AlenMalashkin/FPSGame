using UnityEngine;

namespace Code.Services.InputService
{
	public interface IInputService
	{
		void Enable();
		void Disable();
		Vector2 ReadMoveDirection();
		Vector2 ReadCameraRotation();
		bool ReadReloadButton();
		bool ReadPauseButton();
		bool ReadResumeButton();
		bool ReadBackToMenuButton();
	}
}