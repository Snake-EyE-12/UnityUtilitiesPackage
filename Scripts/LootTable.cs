using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Guymon.Mathematics {
    /// <summary>
    /// Deterministically Random Sample for Situation Game Loot Generation
    /// </summary>
    /// <typeparam name="T0">Object Type Contained in Loot Table</typeparam>
    [System.Serializable]
    public class LootTable<T0>
    {
        [SerializeField] private List<EntryLootTable<T0>> pools = new List<EntryLootTable<T0>>();
        /// <summary>
        /// Randomly Generates the Roll Amount of Loot From Each Pool 
        /// </summary>
        /// <returns>List of Objects Randomly Pulled From Loot Table </returns>
        public List<T0> loot() {
            List<T0> loot = new List<T0>();
            foreach(EntryLootTable<T0> pool in pools) {
                uint totalEntryWeight = calculateTotalWeight(pool);
                for(int i = 0; i < pool.rolls; i++) {
                    float number = Random.Range(0, totalEntryWeight);
                    foreach(WeightTable<T0> table in pool.containedLoot) {
                        number -= table.weight;
                        if(number <= 0) {
                            loot.Add(table.loot);
                            break;
                        }
                    }
                }
            }
            return loot;
        }
        private uint calculateTotalWeight(EntryLootTable<T0> entryLootTable) {
            uint weight = 0;
            foreach(WeightTable<T0> table in entryLootTable.containedLoot) {
                weight += table.weight;
            }
            return weight;
        }


        [System.Serializable]
        public class EntryLootTable<T1>
        {
            public uint rolls;
            public List<WeightTable<T1>> containedLoot;
        }

        [System.Serializable]
        public class WeightTable<T1>
        {
            public uint weight;
            public T1 loot;
        }
    }
}