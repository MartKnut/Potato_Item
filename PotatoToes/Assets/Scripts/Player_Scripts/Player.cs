using InventoryScripts;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public InventoryObject inventory;
        public float moveSpeed = 15;
        private Rigidbody2D rb;
        
        // public string m_Path;

        private void Start()
        {
            // m_Path = Application.dataPath;
            // Debug.Log(m_Path);
            rb = gameObject.GetComponent<Rigidbody2D>();
        }

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
            inventory.container.Clear();
        }

        private void Update()
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector3(x, y).normalized * (moveSpeed * Time.deltaTime);
            
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
