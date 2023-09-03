using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public Slider friendSlider;
    public Slider patSlider;

    public Text friendText;
    public Text patText;

    public void SetHUD(Friendo friend)
    {
        nameText.text = friend.friendoName;
        friendSlider.maxValue = friend.maxFriendship;
        friendSlider.value = friend.currentFriendship;
        patSlider.maxValue = friend.maxPatience;
        patSlider.value = friend.currentPatience;
        friendText.text = friend.currentFriendship + "/" + friend.maxFriendship;
        patText.text = friend.currentPatience + "/" + friend.maxPatience;
    }

    public void SetFriendship(int friendship, int max)
    {
        friendSlider.value = friendship;
        friendText.text = friendship + "/" + max;
    }

    public void SetPatience(int patience, int max)
    {
        patSlider.value = patience;
        patText.text = patience + "/" + max;
    }

}
