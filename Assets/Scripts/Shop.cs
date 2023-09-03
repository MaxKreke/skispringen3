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
            GameObject.Find("Terminal").GetComponent<Terminal>().ToggleCursor(true);
            Camera.main.gameObject.GetComponent<CameraRotation>().captureMouse = false;
            shop.SetActive(true);
            canvas.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Debug.Log("GoodBye");
            GameObject.Find("Terminal").GetComponent<Terminal>().ToggleCursor(false);
            Camera.main.gameObject.GetComponent<CameraRotation>().captureMouse = true;
            shop.SetActive(false);
            canvas.SetActive(true);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
