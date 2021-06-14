using UnityEngine;

namespace ItemScripts
{
    [CreateAssetMenu(fileName = "New Buff Object", menuName = "Inventory System/Items/Buffs")]

    public class BuffObjects : ItemObject
    {
        public int restoreHealthValue;
        public void Awake()
        {
            type = ItemType.Buff;
        }

    }
}

