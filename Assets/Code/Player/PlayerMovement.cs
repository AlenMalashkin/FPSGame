using Code.Services.InputService;
using UnityEngine;
using Zenject;

namespace Code.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		[SerializeField] private float speed;
		
		private IInputService _inputService;
		private CharacterController _characterController;

		[Inject]
		private void Construct(IInputService inputService)
		{
			_inputService = inputService;
		}
		
		private void Awake()
		{
			_characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{
			Move();
		}

		private void Move()
		{
			Vector3 movement = (transform.right * _inputService.ReadMoveDirection().x + 
			                    transform.forward * _inputService.ReadMoveDirection().y) * speed;

			movement += Physics.gravity;

			_characterController.Move(movement * Time.deltaTime);
		}
	}
}