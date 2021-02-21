using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public enum PlayerState
{
    Free = 0,
    Screen = 1
}

public class PlayerManager : MonoBehaviour
{
    [System.Serializable]
    public class OnEventSwitch : UnityEvent<PlayerState> { };

    public FirstPersonLook playerFirstPersonLook;
    public FirstPersonMovement playerFirstPersonMovement;

    private PlayerState currentState;

    public OnEventSwitch OnPlayerStateSwitch;

    private void Start()
    {
        currentState = PlayerState.Free;
    }

    public FirstPersonLook getPlayerLook()
    {
        return (playerFirstPersonLook);
    }
    public FirstPersonMovement getPlayerMove()
    {
        return (playerFirstPersonMovement);
    }
    public void changeState(PlayerState newState)
    {
        currentState = newState;
        OnPlayerStateSwitch.Invoke(currentState);
    }
}
