using UnityEngine;

namespace ItemScripts
{
    public enum ItemType
    {
        Buff,
        Armor,
        Weapon,
        Furniture,
        Block,
        // Default is Material
        Default
    }
    public abstract class ItemObject : ScriptableObject
    {
        
        // public string itemName;
        // public Sprite itemIcon;
        // 
        // public ItemType type;
        // 
        // [Range(1, 100)] public int maxStackSize = 100;
        // 
        // [TextArea(15,20)]
        // public string description;

        public int ID;
        public Sprite uIDisplay;
        public ItemType type;
        [TextArea(15,20)]
        public string description;
    }

    [System.Serializable]
    public class Item
    {
        public string Name;
        public int Id;

        public Item(ItemObject item)
        {
            Name = item.name;
            Id = item.ID;
        }
        
    }
}