using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public GameObject canvas;
    public GameObject shop;
    public GameObject pee;
    public GameObject criminalEnergy;
    public GameObject portal;
    public GameObject police1;
    public GameObject police2;

    private void Start()
    {
        if (Terminal.blastUnlocked) return;
        if (Terminal.handUnlocked)
        {
            GetComponent<Inventory>().inventory.Insert(0,criminalEnergy.GetComponent<Item>());
            return;
        }
        GetComponent<Inventory>().inventory.Insert(0,pee.GetComponent<Item>());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Terminal.ToggleCursor(true);
            Camera.main.gameObject.GetComponent<CameraRotation>().captureMouse = false;
            shop.SetActive(true);
            shop.GetComponent<ShopDisplay>().shop = GetComponent<Inventory>();
            canvas.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Character")
        {
            Terminal.ToggleCursor(false);
            Camera.main.gameObject.GetComponent<CameraRotation>().captureMouse = true;
            if (shop.GetComponent<ShopDisplay>().Klauen())
            {
                Destroy(GetComponent<BoxCollider>());
                portal.SetActive(false);
                police1.SetActive(true);
                police2.SetActive(true);
            }
            shop.SetActive(false);
            canvas.SetActive(true);
        }
    }

    private void Update()
    {
        if (transform.childCount == 0) portal.SetActive(true);
    }

}
