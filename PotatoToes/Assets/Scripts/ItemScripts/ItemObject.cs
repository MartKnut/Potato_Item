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
        
        
        public GameObject prefab;
        public ItemType type;
        [TextArea(15,20)]
        public string description;
    }
}