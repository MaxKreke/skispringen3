using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Moneydisplay : MonoBehaviour
{
    public Inventory player;
    private TextMeshProUGUI tmp;

    private void Start()
    {
        tmp = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        tmp.SetText(player.Money.ToString());
    }
}
