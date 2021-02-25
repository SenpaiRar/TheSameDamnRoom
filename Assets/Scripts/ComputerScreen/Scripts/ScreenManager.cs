using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class ScreenManager : MonoBehaviour
{
    

    public Camera screenRenderCamera;
    public List<Window> windowsOnScreen = new List<Window>();
    public float DistanceBetweenWindows;

    private float initialDistance;
    private float Offset = 1;

    private List<float> zValues = new List<float>();
    
    private void Awake()
    {
        initialDistance = screenRenderCamera.nearClipPlane + Offset + screenRenderCamera.transform.position.z;
        Window.OnWindowSelected += SendToFront;
        
    }

    public void SendToFront(Window w)
    {
        if(w.transform.position.z == initialDistance)
        {
            return;
        }
        else
        {
            foreach (Window s in windowsOnScreen)
            {
                if(s.transform.position.z > w.transform.position.z)
                {
                    //Do Nothing
                }
                else
                {
                    s.transform.position += new Vector3(0,0,DistanceBetweenWindows);
                }
            }
            w.transform.position = new Vector3(w.transform.position.x, w.transform.position.y, initialDistance);
        }
    }

}