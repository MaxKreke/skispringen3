using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    public Inventory inventory;
    private int itemCount;

    void Start()
    {
        itemCount = inventory.inventory.Count;
    }

    // Update is called once per frame
    void Update()
    {
        if (inventory.inventory.Count > itemCount) AddItem(inventory.inventory[inventory.inventory.Count-1]);
        if (inventory.inventory.Count < itemCount) ClearInventory();
    }

    private void AddItem(Item item)
    {
        itemCount++;
    }

    private void ClearInventory()
    {
        itemCount = 0;
    }


}
