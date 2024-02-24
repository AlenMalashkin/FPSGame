using Code.Logic.GameWorld;
using UnityEngine;

namespace Code.Logic
{
    public class Level : MonoBehaviour, IGameWorldPart
    {
        [SerializeField] private GameObject[] gameWorldParts;
        
        public void Initialize()
        {
            foreach (var gameWorldPart in gameWorldParts)
            {
                gameWorldPart.GetComponent<IGameWorldPart>().Initialize();
            }
        }
    }
}