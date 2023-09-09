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
    public GameObject enemyContainer;
    private Terminal terminal;

    private void Start()
    {
        terminal = GameObject.Find("Terminal").GetComponent<Terminal>();
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
            terminal.ShopMusic();
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
                police1.transform.SetParent(enemyContainer.transform);
                police1.transform.SetParent(enemyContainer.transform);
                terminal.PoliceMusic();
            }
            else
            {
                terminal.CombatMusic(false);
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
