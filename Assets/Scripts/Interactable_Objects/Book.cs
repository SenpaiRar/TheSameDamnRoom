using UnityEngine;
using System.Collections;

public class Book : MonoBehaviour, Interactable
{
    public string Blurb;

    public void Interact()
    {

    }
    public string InteractText()
    {
        return (Blurb);
    }
}
