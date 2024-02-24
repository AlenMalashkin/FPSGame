using Code.Data.Models.GameModel;
using Code.UI.Elements.HUD.DesctopHUD;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Services.InputService
{
    public class MobileInputService : IInputService
    {
        private InputControlls _input;
        private IGameModel _gameModel;
        private MobileHud _hud;

        public MobileInputService(InputControlls input, IGameModel gameModel)
        {
            _input = input;
            _gameModel = gameModel;
        }

        public void Enable()
            => _input.Enable();

        public void Disable()
            => _input.Disable();

        public Vector2 ReadMoveDirection()
            => new Vector2(SimpleInput.GetAxis("Horizontal"), SimpleInput.GetAxis("Vertical"));

        public bool ReadReloadButton()
            => SimpleInput.GetButtonUp("Reload");

        public Vector2 ReadCameraRotation()
        {
            _hud = _gameModel.HUD as MobileHud;

            if (CheckTouchZone(_input.Game.TouchPosition))
                return MoveCameraByInputAction(_input.Game.MoveCamera);
            
            if (CheckTouchZone(_input.Game.SecondFingerTouchPosition))
                return MoveCameraByInputAction(_input.Game.SecondFingerMoveCamera);
            
            return new Vector2();
        }

        public bool ReadPauseButton()
            => SimpleInput.GetButtonUp("Pause");

        public bool ReadResumeButton()
            => SimpleInput.GetButtonUp("Resume");

        public bool ReadBackToMenuButton()
            => SimpleInput.GetButtonUp("BackToMenu");

        private bool CheckTouchZone(InputAction touchInputAction) 
            => RectTransformUtility.RectangleContainsScreenPoint(_hud!.CameraRotationZone, touchInputAction.ReadValue<Vector2>());
        
        private Vector2 MoveCameraByInputAction(InputAction moveCameraInputAction)
            => moveCameraInputAction.ReadValue<Vector2>();
    }
}