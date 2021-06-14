using InventoryScripts;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public InventoryObject inventory;

        public void OnTriggerEnter2D(Collider2D other)
        {
            var item = other.GetComponent<Item>();
            if (item)
            {
                inventory.AddItem(item.item, 1);
                Destroy(other.gameObject);
            }
        }
    
        private void OnApplicationQuit()
        {
            inventory.Container.Clear();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                inventory.Save();
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                inventory.Load();
            }
        }
    }
}