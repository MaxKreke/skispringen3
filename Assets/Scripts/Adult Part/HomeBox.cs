using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeBox : MonoBehaviour
{
    public TamagochiVoice voice;
    public GameObject pee;
    public GameObject criminalEnergy;
    private bool visited;

    private void Start()
    {
        visited = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (visited) return;
        if (other.gameObject.tag == "Character")
        {
            Inventory playerinv = other.gameObject.GetComponent<Inventory>();
            foreach(Item item in playerinv.inventory) {
                Terminal.hygiene += item.Hygiene;
                Terminal.charisma += item.Charisma;
                Terminal.joy += item.Joy;
                Terminal.tomfoolery += item.Tomfoolery;
                Terminal.anger += item.Anger;
                Terminal.will += item.Will;
                Terminal.fashion += item.Fashion;
                Terminal.empathy += item.Empathy;
            }
            playerinv.inventory.Clear();
            if (!Terminal.levelCleared) return;
            voice.ReturnHome();
            if (Terminal.blastUnlocked) return;
            if (Terminal.handUnlocked)
            {
                criminalEnergy.SetActive(true);
                return;
            }
            pee.SetActive(true);
            visited = true;
        }
    }
}
