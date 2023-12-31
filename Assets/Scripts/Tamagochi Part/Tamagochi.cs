using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tamagochi : MonoBehaviour
{
    public string tamaName;

    public int hygiene;
    public int charisma;
    public int joy;
    public int tomfoolery;
    public int fashion;
    public int empathy;
    public int will;
    public int anger;

    private void Start()
    {
        hygiene = Terminal.hygiene;
        charisma = Terminal.charisma;
        joy = Terminal.joy;
        tomfoolery = Terminal.tomfoolery;
        fashion = Terminal.fashion;
        empathy = Terminal.empathy;
        will = Terminal.will;
        anger = Terminal.anger;
    }
}
