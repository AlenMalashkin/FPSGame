using Code.Enemy;
using UnityEngine;

namespace Code.StaticData.EnemyStaticData
{
    [CreateAssetMenu(fileName = "EnemyStaticData", menuName = "EnemyStaticData", order = 0)]
    public class EnemyStaticData : ScriptableObject
    {
        public EnemyType Type;
        public GameObject EnemyPrefab;
        public int Health;
        public int Damage;
    }
}