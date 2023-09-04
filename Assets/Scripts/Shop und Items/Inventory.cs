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
        Money = Terminal.Money;
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

    public void AddItem(Item item)
    {
        if (item.MoneyValue > 0)
        {
            Money += item.MoneyValue;
            Terminal.Money += item.MoneyValue;
            return;
        }
        if (item.Pee)
        {
            ws.ActivateHand();
            Terminal.handUnlocked = true;
            return;
        }
        if (item.CriminalEnergy)
        {
            ws.ActivateBlast();
            Terminal.blastUnlocked = true;
            return;
        }
        inventory.Add(item);

    }
}
