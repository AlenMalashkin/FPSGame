using Code.Logic.GameModes;
using UnityEngine;

namespace Code.StaticData.LevelStaticData
{
    [CreateAssetMenu(fileName = "LevelStaticData", menuName = "Levels Static Data", order = 6)]
    public class LevelStaticData : ScriptableObject
    {
        [SerializeField] private GameModes gameMode;
        [SerializeField] private GameObject levelPrefab;

        public GameModes GameMode => gameMode;
        public GameObject LevelPrefab => levelPrefab;
    }
}