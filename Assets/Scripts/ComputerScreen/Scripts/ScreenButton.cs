using UnityEngine;
using System.Collections;
using UnityEngine.Events;
public class ScreenButton : MonoBehaviour, IScreenInteractable
{

    public UnityEvent onButton = new UnityEvent();

    
    public void OnLongClick()
    {
        //Do Nothing
    }
    
    public void OnShortClick()
    {
        onButton.Invoke();
    }
    public void OnInitClick()
    {

    }
}
