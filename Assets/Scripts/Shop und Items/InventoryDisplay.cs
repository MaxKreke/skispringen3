using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    public GameObject prefab;
    private int itemCount;

    void Start()
    {
        itemCount = inventory.inventory.Count;
    }

    void Update()
    {
        if (inventory.inventory.Count > itemCount) AddItem(inventory.inventory[itemCount]);
        if (inventory.inventory.Count < itemCount) ClearInventory();
    }

    private void AddItem(Item item)
    {
        GameObject itemDisplay = Instantiate(prefab,transform.GetChild(0));
        itemDisplay.GetComponent<RawImage>().texture = item.img;
        itemDisplay.GetComponent<RectTransform>().anchoredPosition -= new Vector2(0, 100)*(itemCount);
        itemCount++;
    }

    private void ClearInventory()
    {
        itemCount = 0;
        foreach(Transform child in transform.GetChild(0))
        {
            Destroy(child.gameObject);
        }
    }


}
