using UnityEngine;
namespace ItemScripts
{
    [CreateAssetMenu(fileName = "New Block Object", menuName = "Inventory System/Items/Block")]

    public class BlockObject : ItemObject
    {
        public bool isWall;

        private void Awake()
        { 
            type = ItemType.Block;
        }
        
    }
}
