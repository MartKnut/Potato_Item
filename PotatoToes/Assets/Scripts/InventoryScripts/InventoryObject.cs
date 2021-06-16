using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Database;
using ItemScripts;
using UnityEngine;

namespace InventoryScripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject, ISerializationCallbackReceiver
    {
        public string savePath;
        private ItemDatabaseObject _database;
        public List<InventorySlot> container = new List<InventorySlot>();
        private void OnEnable()
        {
#if UNITY_EDITOR
            _database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
            _database = Resources.Load<ItemDatabaseObject>("Database.asset");
#endif
        }
        
        public void AddItem(ItemObject _item, int _amount)
        {
            for (int i = 0; i < container.Count; i++)
            {
                if (container[i].item == _item)
                {
                    container[i].AddAmount(_amount);
                    return;
                }
            }
            container.Add(new InventorySlot(_database.GetID[_item], _item, _amount));
            
        }

        public void Save()
        {
            string saveData = JsonUtility.ToJson(this, true);
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
            bf.Serialize(file,saveData);
            file.Close();
        }
        public void Load()
        {
            if (File.Exists(string.Concat(Application.persistentDataPath, savePath))) 
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
                JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
                file.Close();
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            for (int i = 0; i < container.Count; i++) container[i].item = _database.GetItem[container[i].ID];
        }
    }

    [System.Serializable]
    public class InventorySlot
    {
        public int ID;
        public ItemObject item;
        public int amount;
        public InventorySlot(int _id, ItemObject _item, int _amount)
        {
            ID = _id;
            item = _item;
            amount = _amount;
        }

        public void AddAmount(int value)
        {
            amount += value;
        }
    }
}

