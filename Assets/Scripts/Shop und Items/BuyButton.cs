using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyButton : MonoBehaviour
{
    public void click()
    {
        transform.parent.parent.GetComponent<ShopDisplay>().Buy();
    }

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(click);
    }

}
