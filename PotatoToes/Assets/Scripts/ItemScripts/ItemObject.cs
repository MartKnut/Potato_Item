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

    public enum Attributes
    {
        Agility,
        Intellect,
        Stamina,
        Strength
    }
    public abstract class ItemObject : ScriptableObject
    {
        public int ID;
        public Sprite uIDisplay;
        public ItemType type;
        [TextArea(15,20)]
        public string description;
        public ItemBuff[] buffs;

        public Item CreateItem()
        {
            Item newItem = new Item(this);
            return newItem;
        }
    }

    [System.Serializable]
    public class Item
    {
        public string Name;
        public int Id;
        public ItemBuff[] buffs;

        public Item(ItemObject item)
        {
            Name = item.name;
            Id = item.ID;
            buffs = new ItemBuff[item.buffs.Length];
            for (int i = 0; i < buffs.Length; i++)
            {
                buffs[i] = new ItemBuff(item.buffs[i].min, item.buffs[i].max);
                {
                    buffs[i].attribute = item.buffs[i].attribute;
                }
            }
        }
        
    }

    [System.Serializable]
    public class ItemBuff
    {
        public Attributes attribute;
        public int value;
        public int min;
        public int max;

        public ItemBuff(int _min, int _max)
        {
            min = _min;
            max = _max;
            GenerateValue();
        }

        public void GenerateValue()
        {
            value = UnityEngine.Random.Range(min, max);
        }
    }
}