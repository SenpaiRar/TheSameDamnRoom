using UnityEngine;
using System.Collections;

public class Window : MonoBehaviour, IScreenInteractable
{
    private NewMouse playerMouse;
    private MeshRenderer meshRenderer;
    private MeshCollider meshCollider;

    private MeshRenderer[] childMeshRenderers;
    private MeshCollider[] childMeshColliders;

    private bool isVisible;


    public delegate void OnWindowEvent(Window w);
    public static event OnWindowEvent OnWindowSelected;


    private void Awake()
    {
        playerMouse = GameObject.Find("Cursor").GetComponent<NewMouse>();
        meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshCollider = gameObject.GetComponent<MeshCollider>();

        childMeshRenderers = gameObject.GetComponentsInChildren<MeshRenderer>();
        childMeshColliders = gameObject.GetComponentsInChildren<MeshCollider>();

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
        meshCollider.enabled = isVisible;
        foreach (var item in childMeshRenderers)
        {
            item.enabled = isVisible;
        }
        foreach (var item in childMeshColliders)
        {
            item.enabled = isVisible;
        }
    }
    public void ToggleWindow()
    {
        isVisible = !isVisible;
        meshRenderer.enabled = isVisible;
        meshCollider.enabled = isVisible;
        foreach (var item in childMeshRenderers)
        {
            item.enabled = isVisible;
        }
        foreach (var item in childMeshColliders)
        {
            item.enabled = isVisible;
        }

    }
    public void OnInitClick()
    {
        if (OnWindowSelected != null)
            OnWindowSelected.Invoke(this);
    }
    

}
