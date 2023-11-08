using Code.Logic.GameWorld;
using Code.Services;
using UnityEngine;
using Zenject;

namespace Code.Logic
{
    public class Level : MonoBehaviour, IGameWorldPart
    {
        [SerializeField] private GameObject[] gameWorldParts;

        private IEnemySpawnTimeReduceService _enemySpawnTimeReduceService;
        
        [Inject]
        private void Construct(IEnemySpawnTimeReduceService enemySpawnTimeReduceService)
        {
            _enemySpawnTimeReduceService = enemySpawnTimeReduceService;
        }
        
        public void Initialize()
        {
            foreach (var gameWorldPart in gameWorldParts)
            {
                gameWorldPart.GetComponent<IGameWorldPart>().Initialize();
            }
            
            _enemySpawnTimeReduceService.StartReduce();
        }
    }
}