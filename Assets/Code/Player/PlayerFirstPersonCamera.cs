using UnityEngine;

namespace Code.Player
{
	public class PlayerFirstPersonCamera : MonoBehaviour
	{
		[SerializeField] private PlayerInput playerInput;
		[SerializeField] private CharacterController playerBody;
		[SerializeField] private Camera firstPersonCamera;
		[SerializeField] private float minY;
		[SerializeField] private float maxY;
		[SerializeField] private float sensitivity;

		private float _cameraRotationX;
		private float _cameraRotationY;

		void Start()
		{
			_cameraRotationX = 0;
			_cameraRotationY = 0;
		}

		private void Update()
		{
			_cameraRotationX += playerInput.ReadMouseDelta().x * sensitivity;
			_cameraRotationY += playerInput.ReadMouseDelta().y * sensitivity;

			_cameraRotationY = Mathf.Clamp(_cameraRotationY, minY, maxY);

			CameraRotation();
		}

		private void CameraRotation()
		{
			playerBody.transform.rotation = Quaternion.Euler(0, _cameraRotationX, 0);
			firstPersonCamera.transform.rotation = Quaternion.Euler(-_cameraRotationY, _cameraRotationX, 0);
		}
	}
}