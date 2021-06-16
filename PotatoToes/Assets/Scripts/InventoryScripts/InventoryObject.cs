using UnityEditor;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Database;
using ItemScripts;
using UnityEngine;

namespace InventoryScripts
{
    [CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")]
    public class InventoryObject : ScriptableObject
    {
        private string gamePath;
        public string savePath;
        public ItemDatabaseObject _database;
        public Inventory container;
        
        /* private void OnEnable() {
#if UNITY_EDITOR
            _database = (ItemDatabaseObject)AssetDatabase.LoadAssetAtPath("Assets/Resources/Database.asset", typeof(ItemDatabaseObject));
#else
            _database = Resources.Load<ItemDatabaseObject>("Database");
#endif
        } */
        
        public void AddItem(Item _item, int _amount)
        {

            if (_item.buffs.Length > 0)
            {
                container.Items.Add(new InventorySlot(_item.Id, _item, _amount));
                return;
            }
            
            for (int i = 0; i < container.Items.Count; i++)
            {
                if (container.Items[i].item.Id == _item.Id)
                {
                    container.Items[i].AddAmount(_amount);
                    return;
                }
            }
            container.Items.Add(new InventorySlot(_item.Id, _item, _amount));
        }

        [ContextMenu("Save")]
        public void Save()
        {
           // string saveData = JsonUtility.ToJson(this, true);
           // BinaryFormatter bf = new BinaryFormatter();
           // FileStream file = File.Create(string.Concat(Application.persistentDataPath, savePath));
           // bf.Serialize(file,saveData);
           // file.Close();
           
           IFormatter formatter = new BinaryFormatter();
           Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath), FileMode.Create, FileAccess.Write);
           formatter.Serialize(stream,container);
           stream.Close();
        }
        [ContextMenu("Load")]
        public void Load()
        {
            if (File.Exists(string.Concat(Application.persistentDataPath, savePath))) 
            {
                // BinaryFormatter bf = new BinaryFormatter();
                // FileStream file = File.Open(string.Concat(Application.persistentDataPath, savePath), FileMode.Open);
                // JsonUtility.FromJsonOverwrite(bf.Deserialize(file).ToString(),this);
                // file.Close();
                
                IFormatter formatter =new BinaryFormatter();
                Stream stream = new FileStream(string.Concat(Application.persistentDataPath, savePath),FileMode.Open,FileAccess.Read);
                container = (Inventory) formatter.Deserialize(stream);
                stream.Close();
            }
        }
        [ContextMenu("Clear")]
        public void Clear()
        {
            container = new Inventory();
        }
    }

    [System.Serializable]
    public class Inventory
    {
        public List<InventorySlot> Items = new List<InventorySlot>();

    }
    [System.Serializable]
    public class InventorySlot
    {
        public int ID;
        public Item item;
        public int amount;
        public InventorySlot(int _id, Item _item, int _amount)
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

