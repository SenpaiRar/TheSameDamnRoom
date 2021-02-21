using UnityEngine;
using System.Collections;

public class Screen_State : MonoBehaviour
{
    public PlayerManager playerManager;


    //Position where we lock player in screen state
    public Transform inScreenStatePoint;
    //Position where we put player after they leave screen state
    public Transform outScreenStatePoint;

    public Camera screenCamera;
    public Camera playerCamera;

    public void EnterScreenState(PlayerState newState)
    {
        if (newState == PlayerState.Screen)
        {
            playerManager.getPlayerMove().ToggleMovement(false);
            playerManager.getPlayerLook().ToggleLook(false);
            playerCamera.enabled = false;
            screenCamera.enabled = true;
            
        }
        
    }

    public void LeaveScreenState()
    {
        playerManager.getPlayerMove().ToggleMovement(true);
        playerManager.getPlayerLook().ToggleLook(true);
        playerCamera.enabled = true;
        screenCamera.enabled = false;

    }



}
