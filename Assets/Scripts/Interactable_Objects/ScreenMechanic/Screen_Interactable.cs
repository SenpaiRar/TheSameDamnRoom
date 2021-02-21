using UnityEngine;
using System.Collections;

public class  Screen_Interactable: MonoBehaviour, Interactable
{
    public void Interact()
    {
        GameObject.Find("Player").GetComponent<PlayerManager>().changeState(PlayerState.Screen);
    }
    public string InteractText()
    {
        //Because it manipulates the player, this can be empty
        return ("");
    }
}
