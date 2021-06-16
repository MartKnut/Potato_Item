using InventoryScripts;
using ItemScripts;
using UnityEngine;

namespace Player_Scripts
{
    public class Player : MonoBehaviour
    {
        public InventoryObject inventory;
        public float moveSpeed = 200;
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
            var item = other.GetComponent<GroundItem>();
            if (item)
            {
                inventory.AddItem(new Item(item.groundItem), 1);
                Destroy(other.gameObject);
            }
        }
    
        private void OnApplicationQuit()
        {
            inventory.container.Items.Clear();
        }

        private void Update()
        {
            Movement();
            SaveLoad();
        }
        
        private void Movement() 
        {
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            rb.velocity = new Vector3(x, y).normalized * (moveSpeed * Time.deltaTime);
        }
        
        void SaveLoad()
        {
            if (Input.GetKeyDown(KeyCode.K)) inventory.Save();
            if (Input.GetKeyDown(KeyCode.L)) inventory.Load();
        }
    }
}
