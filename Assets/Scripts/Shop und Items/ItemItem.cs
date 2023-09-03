using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemItem : MonoBehaviour
{
    public int shopID = -1;
    public int cartID = -1;
    public Item item;
    public int preis;

    public void click()
    {
        transform.parent.parent.parent.GetComponent<ShopDisplay>().Signal(this);
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(click);
    }

    public void LateUpdate()
    {
        preis = item.Kaufpreis;
        GetComponent<RawImage>().texture = item.img;
        transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(item.name);
        transform.GetChild(1).GetComponent<TextMeshProUGUI>().SetText(preis.ToString()+ " Tokens");
    }
    

}
