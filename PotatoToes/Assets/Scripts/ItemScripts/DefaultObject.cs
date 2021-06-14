using UnityEngine;

namespace ItemScripts
{
    [CreateAssetMenu(fileName = "New Material Object", menuName = "Inventory System/Items/Material")]
    public class DefaultObject : ItemObject
    {
        public void Awake()
        {
            type = ItemType.Default;
        }
        
    }
}
