using System.Linq;
using Code.Data.Models.GameModel;
using Code.Logic;
using UnityEngine;
using VavilichevGD.Utils.Timing;
using Zenject;

namespace Code.Enemy
{
	public class EnemyAttack : MonoBehaviour
	{
		[SerializeField] private EnemyMovement movement;
		[SerializeField] private int damage = 10;
		[SerializeField] private float attackRate = 1f;
		[SerializeField] private float cleavage = 0.5f;
		[SerializeField] private LayerMask mask;

		private IGameModel _gameModel;
		private GameObject _player;
		private Collider[] _hits = new Collider[1];
		private SyncedTimer _attackRateTimer;
		private bool _canAttack;

		[Inject]
		private void Construct(IGameModel gameModel)
		{
			_gameModel = gameModel;
		}
		
		private void Awake()
		{
			_player = _gameModel.Player;
			_attackRateTimer = new SyncedTimer(TimerType.UpdateTick);
		}

		private void OnEnable()
		{
			_attackRateTimer.TimerFinished += Attack;
		}

		private void OnDisable()
		{
			_attackRateTimer.TimerFinished -= Attack;
		}

		private void Update()
		{
			transform.LookAt(_player.transform);
		}

		private void Attack()
		{
			OnAttack();
			
			if (_canAttack)
				_attackRateTimer.Start(attackRate);
		}

		private void OnAttack()
		{
			DrawDebug(AttackPosition(), cleavage, 1);
			if (Hit(out Collider other))
				other.gameObject.GetComponent<IHealth>().TakeDamage(damage);
		}

		private bool Hit(out Collider hit)
		{
			var hitAmount = Physics.OverlapSphereNonAlloc(AttackPosition(), cleavage, _hits, mask);

			hit = _hits.FirstOrDefault();

			return hitAmount > 0;
		}
		
		private static void DrawDebug(Vector3 worldPos, float radius, float seconds)
		{
			Debug.DrawRay(worldPos, radius * Vector3.up, Color.red, seconds);
			Debug.DrawRay(worldPos, radius * Vector3.down, Color.red, seconds);
			Debug.DrawRay(worldPos, radius * Vector3.left, Color.red, seconds);
			Debug.DrawRay(worldPos, radius * Vector3.right, Color.red, seconds);
			Debug.DrawRay(worldPos, radius * Vector3.forward, Color.red, seconds);
			Debug.DrawRay(worldPos, radius * Vector3.back, Color.red, seconds);
		}

		private Vector3 AttackPosition()
			=> new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z) +
				transform.forward * 1;

		public void EnableAttack()
		{
			_canAttack = true;
			_attackRateTimer.Start(attackRate);
			movement.Stop();
		}


		public void DisableAttack()
		{
			_canAttack = false;
			_attackRateTimer.Stop();
			movement.Move();
		}
	}
}