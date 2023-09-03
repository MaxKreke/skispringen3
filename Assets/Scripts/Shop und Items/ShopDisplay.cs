using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopDisplay : MonoBehaviour
{

    public TextMeshProUGUI tmp;
    public TextMeshProUGUI moneytmp;
    public int cost = 0;
    public Inventory player;
    public Inventory shop;
    private Inventory own;
    public GameObject prefab;

    public void Start()
    {
        own = GetComponent<Inventory>();
        LoadInventory();
    }

    private void LoadInventory()
    {
        ClearInventory();
        for(int i = 0; i < shop.inventory.Count; i++)
        {
            Item item = shop.inventory[i];
            GameObject itemDisplay = Instantiate(prefab, transform.GetChild(0).GetChild(1));
            itemDisplay.GetComponent<RectTransform>().anchoredPosition -= i*new Vector2(0, 100);
            itemDisplay.GetComponent<ItemItem>().item = item;
            itemDisplay.GetComponent<ItemItem>().shopID = i;
            itemDisplay.GetComponent<ItemItem>().cartID = -1;
        }
        for (int i = 0; i < own.inventory.Count; i++)
        {
            Item item = own.inventory[i];
            GameObject itemDisplay = Instantiate(prefab, transform.GetChild(1).GetChild(1));
            itemDisplay.GetComponent<RectTransform>().anchoredPosition -= i*new Vector2(0, 100);
            itemDisplay.GetComponent<ItemItem>().item = item;
            itemDisplay.GetComponent<ItemItem>().cartID = i;
            itemDisplay.GetComponent<ItemItem>().shopID = -1;
        }
    }

    private void Update()
    {
        tmp.SetText($"Cost: {cost} Tokens");
        moneytmp.SetText($"Funds: {player.Money} Tokens");
        if (cost > player.Money) tmp.color = Color.red;
        else tmp.color = Color.black;
    }

    public void Signal(ItemItem item)
    {
        if (item.cartID == -1)AddToCart(item);
        else RemoveFromCart(item);
    }

    public void AddToCart(ItemItem item)
    {
        shop.inventory.RemoveAt(item.shopID);
        own.inventory.Add(item.item);
        LoadInventory();
        cost += item.preis;
    }

    public void RemoveFromCart(ItemItem item)
    {
        own.inventory.RemoveAt(item.cartID);
        shop.inventory.Add(item.item);
        LoadInventory();
        cost -= item.preis;
    }

    public void ClearInventory()
    {
        foreach (Transform child in transform.GetChild(0).GetChild(1))
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in transform.GetChild(1).GetChild(1))
        {
            Destroy(child.gameObject);
        }
    }

    public void Buy()
    {
        if(cost <= player.Money)
        {
            player.Money -= cost;
            cost = 0;
            foreach(Item item in own.inventory)
            {
                player.AddItem(item);
            }
            own.inventory.Clear();
            LoadInventory();
        }
    }

    public void Klauen()
    {
        if(own.inventory.Count > 0)
        {
            foreach (Item item in own.inventory)
            {
                player.AddItem(item);
            }
            own.inventory.Clear();
            LoadInventory();
            Debug.LogError("KLAUEN");
        }
    }

}
