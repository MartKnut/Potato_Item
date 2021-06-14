using System.Collections.Generic;
using ItemScripts;
using UnityEngine;

namespace Database
{
    [CreateAssetMenu(fileName = "New Item Database", menuName = "Inventory System/Items/Database")]
    
    public class ItemDatabaseObject : ScriptableObject, ISerializationCallbackReceiver
    {
        public ItemObject[] Items;
        public Dictionary<ItemObject, int> GetID = new Dictionary<ItemObject, int>();
        public Dictionary<int, ItemObject> GetItem = new Dictionary<int, ItemObject>();

        
        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            GetID = new Dictionary<ItemObject, int>();
            GetItem = new Dictionary<int, ItemObject>();
            for (int i = 0; i < Items.Length; i++)
            {
                GetID.Add(Items[i], i);
                GetItem.Add(i, Items[i]);
            }
        }
    }
}
