using UnityEngine;

namespace Code.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		private PlayerInput _playerInput;
		private CharacterController _characterController;

		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
			_playerInput = GetComponent<PlayerInput>();
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			Vector3 movement = (transform.right * _playerInput.ReadMoveDirection().x + 
			                    transform.forward * _playerInput.ReadMoveDirection().y) * 20;

			movement += Physics.gravity;

			_characterController.Move(movement * Time.deltaTime);
		}
	}
}