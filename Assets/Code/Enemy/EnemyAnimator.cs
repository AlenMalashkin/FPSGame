using System.Collections.Generic;
using UnityEngine;

namespace Code.Enemy
{
    public class EnemyAnimator : MonoBehaviour
    {
        private const string Idling = "Idling";
        private const string Walking = "Walking";
        private const string Attacking = "Attacking";
        private const string Die = "Die";

        [SerializeField] private Animator animator;
        
        private Dictionary<EnemyAnimationStates, string> _enemyAnimationsMap = new Dictionary<EnemyAnimationStates, string>()
        {
            [EnemyAnimationStates.Idle] = Idling,
            [EnemyAnimationStates.Walk] = Walking,
            [EnemyAnimationStates.Attack] = Attacking,
        };

        private EnemyAnimationStates _currentState;

        public void ChangeAnimationState(EnemyAnimationStates state)
        {
            animator.SetBool(_enemyAnimationsMap[_currentState], false);
            _currentState = state;
            animator.SetBool(_enemyAnimationsMap[state], true);
        }

        public void PlayDie()
            => animator.SetTrigger(Die);
    }
}