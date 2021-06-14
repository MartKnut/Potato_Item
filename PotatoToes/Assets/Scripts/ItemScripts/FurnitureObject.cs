using UnityEngine;

namespace ItemScripts
{
    [CreateAssetMenu(fileName = "New Furniture Object", menuName = "Inventory System/Items/Furniture")]

    public class FurnitureObject : ItemObject
    {
        public int height;
        public int width;

        public bool canSmelt;
        public bool canSmith;
        public bool canCraft;
        public bool canAlchemy;

        public bool open = false;
        
        private void Awake()
        {
            type = ItemType.Furniture;
        }
    }
}
