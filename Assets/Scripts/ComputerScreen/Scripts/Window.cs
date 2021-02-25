using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour, IScreenInteractable
{
    private NewMouse playerMouse;
    private MeshRenderer meshRenderer;

    private bool isVisible;


    public delegate void OnWindowEvent(Window w);
    public static event OnWindowEvent OnWindowSelected;


    private void Awake()
    {
        playerMouse = GameObject.Find("Cursor").GetComponent<NewMouse>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    public void OnLongClick()
    {
        transform.parent = playerMouse.transform;
    }

    public void OnShortClick()
    {
        transform.parent = null;
    }

    public void ToggleWindow(bool newState)
    {
        isVisible = newState;
        meshRenderer.enabled = isVisible;
    }
    public void ToggleWindow()
    {
        isVisible = !isVisible;
        meshRenderer.enabled = isVisible;
    }
    public void OnInitClick()
    {
        if (OnWindowSelected != null)
            OnWindowSelected.Invoke(this);
    }
    

}
