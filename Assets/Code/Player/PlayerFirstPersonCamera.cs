using Code.Services.InputService;
using Code.Services.PauseService;
using UnityEngine;
using Zenject;

namespace Code.Player
{
	public class PlayerFirstPersonCamera : MonoBehaviour
	{
		[SerializeField] private CharacterController playerBody;
		[SerializeField] private Camera firstPersonCamera;
		[SerializeField] private Camera weaponCamera;
		[SerializeField] private float minY;
		[SerializeField] private float maxY;
		[SerializeField] private float sensitivity;

		private IInputService _inputService;
		private IPauseService _pauseService;
		
		private float _cameraRotationX;
		private float _cameraRotationY;

		[Inject]
		private void Construct(IInputService inputService, IPauseService pauseService)
		{
			_inputService = inputService;
			_pauseService = pauseService;
		}
		
		private void Start()
		{
			_cameraRotationX = 0;
			_cameraRotationY = 0;
		}

		private void Update()
		{
			if (_pauseService.Paused) 
				return;
			
			_cameraRotationX += _inputService.ReadCameraRotation().x * sensitivity;
			_cameraRotationY += _inputService.ReadCameraRotation().y * sensitivity;

			_cameraRotationY = Mathf.Clamp(_cameraRotationY, minY, maxY);

			CameraRotation();
		}

		private void CameraRotation()
		{
			playerBody.transform.rotation = Quaternion.Euler(0, _cameraRotationX, 0);
			firstPersonCamera.transform.rotation = Quaternion.Euler(-_cameraRotationY, _cameraRotationX, 0);
			weaponCamera.transform.rotation = Quaternion.Euler(-_cameraRotationY, _cameraRotationX, 0);
		}
	}
}