using UnityEngine;

namespace ItemScripts
{
    [CreateAssetMenu(fileName = "New Equipment Object", menuName = "Inventory System/Items/Equipment")]
    
    public class ArmorObject : ItemObject
    {
        [Header("Adds attack")]
        public float atkBonus;
        [Header("Adds defence")]
        public float defBonus;
        [Header("Adds more mana to mana pool")]
        public float manaBonus;
        [Header("%Chance for ammo not to be used")]
        public float ammoBonus;
        
        [Space]
        
        [Header("What type of armor it is, and where the atkBonus should go")]
        public bool isMelee;
        public bool isRanged;
        public bool isMagic;
        
        private void Awake()
        {
            type = ItemType.Armor;
        }
    }

}
