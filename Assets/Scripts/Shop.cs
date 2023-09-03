using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject canvas;
    public GameObject shop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("shop");
            //shop.SetActive(true);
            //canvas.SetActive(false);
        }
    }

    private void OnTriggerLeave(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("GoodBye");
            //shop.SetActive(false);
            //canvas.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
