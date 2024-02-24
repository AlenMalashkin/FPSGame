using Code.Logic.Loot;
using UnityEngine;

namespace Code.StaticData.LootStaticData
{
    [CreateAssetMenu(fileName = "LootStaticData", menuName = "Loot", order = 0)]
    public class LootStaticData : ScriptableObject
    {
        [SerializeField] private LootType lootType;
        [SerializeField] private Loot lootPrefab;

        public LootType LootType => lootType;
        public Loot LootPrefab => lootPrefab;
    }
}