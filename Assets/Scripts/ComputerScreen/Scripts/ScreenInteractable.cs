using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenInteractable : MonoBehaviour, Interactable
{
    public Transform inScreen;
    public Transform outScreen;

    public FirstPersonLook playerLook;
    public FirstPersonMovement playerMove;

    public GameObject Player;

    public Camera screenCamera;
    public Camera playerCamera;


    public delegate void ScreenState();
    public static event ScreenState OnScreenEnter;
    public static event ScreenState OnScreenExit;
    public void Interact()
    {
        EnterScreenState();
    }
    public string InteractText()
    {
        return ("");
    }
    public void EnterScreenState()
    {
        Player.transform.position = inScreen.position;

        screenCamera.enabled = true;
        playerCamera.enabled = false;

        playerMove.ToggleMovement(false);
        playerLook.ToggleLook(false);

        if (OnScreenEnter != null)
            OnScreenEnter.Invoke();
    }
    public void ExitScreenState()
    {
        Player.transform.position = outScreen.position;

        screenCamera.enabled = false;
        playerCamera.enabled = true;

        playerMove.ToggleMovement(true);
        playerLook.ToggleLook(true);

        if (OnScreenExit != null)
            OnScreenExit.Invoke();
    }
}
