using UnityEngine;

namespace ItemScripts
{
    [CreateAssetMenu(fileName = "New Weapon Object", menuName = "Inventory System/Items/Weapon")]
    
    public class WeaponObject : ItemObject
    {
        [Header("Adds attack")]
        public float atkBonus;

        [Space]
        
        [Header("What type of armor it is, and where the atkBonus should go")]
        public bool isMelee;
        public bool isRanged;
        public bool isMagic;
        
        private void Awake()
        {
            type = ItemType.Weapon;
        }
    }

}