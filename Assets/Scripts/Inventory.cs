using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Money;
    public List<Item> inventory;
    public Weaponswitch ws;

    void Start()
    {
        ws = GetComponent<Weaponswitch>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Item")
        {
            AddItem(other.gameObject.GetComponent<Item>());
            other.gameObject.SetActive(false);
        }
    }

    private void AddItem(Item item)
    {
        if (item.MoneyValue > 0)
        {
            Money += item.MoneyValue;
            return;
        }
        inventory.Add(item);

    }
}
