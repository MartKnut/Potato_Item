using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

namespace InventoryScripts
{
    public class DisplayInventory : MonoBehaviour
    {
        public InventoryObject inventory;
        public GameObject inventoryPrefab;

        public int X_START;
        public int Y_START;
        public int X_SPACE_BETWEEN_ITEM;
        public int NUMBER_OF_COLUMN;
        public int Y_SPACE_BETWEEN_ITEM;
        Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    
        // Start is called before the first frame update
        void Start()
        {
            CreateDisplay();
        }

        // Update is called once per frame
        void Update()
        {
            UpdateDisplay();
        }

        public void CreateDisplay()
        {
            for (int i = 0; i < inventory.container.Items.Count; i++)
            {
                InventorySlot slot = inventory.container.Items[i];

                var obj = Instantiate(inventoryPrefab, Vector3.zero, quaternion.identity, transform);
                obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite =
                    inventory._database.GetItem[slot.item.Id].uIDisplay;
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                itemsDisplayed.Add(slot, obj);
            }
        }

        public void UpdateDisplay()
        {
            for (int i = 0; i < inventory.container.Items.Count; i++)
            {
                InventorySlot slot = inventory.container.Items[i];
                if (itemsDisplayed.ContainsKey(slot))
                {
                    itemsDisplayed[slot].GetComponentInChildren<TextMeshProUGUI>().text =
                        slot.amount.ToString("n0");
                }
                else
                {
                    var obj = Instantiate(inventoryPrefab, Vector3.zero, quaternion.identity, transform);
                    obj.transform.GetChild(0).GetComponentInChildren<Image>().sprite =
                        inventory._database.GetItem[slot.item.Id].uIDisplay;
                    obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                    obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
                    itemsDisplayed.Add(inventory.container.Items[i], obj);
                }
            }
        }

        public Vector3 GetPosition(int i)
        {
            return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)),
                Y_START + (-Y_SPACE_BETWEEN_ITEM * (i / NUMBER_OF_COLUMN)), 0f);
        }
    }
}
