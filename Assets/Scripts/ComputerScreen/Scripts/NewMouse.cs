using UnityEngine;
using System.Collections;

public class NewMouse : MonoBehaviour
{
    public float Speed;
    public float longClickThreshold;

    public Transform cornerOne;
    public Transform cornerTwo;

    public ScreenManager screenManager;

    private IScreenInteractable hoveredInteractable;

    private float mouseDownTime;
    private bool mouseEnabled;

    private void Awake()
    {
        ScreenInteractable.OnScreenEnter += EnableMouse;
        ScreenInteractable.OnScreenExit += DisableMouse;
    }

    private void Start()
    {
        DisableMouse();
    }

    private void Update()
    {
        if (mouseEnabled)
        {
            transform.Translate(new Vector3(Speed * Input.GetAxis("Mouse X"), Speed * Input.GetAxis("Mouse Y"), 0) * Time.deltaTime);
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, cornerOne.position.x, cornerTwo.position.x),
                Mathf.Clamp(transform.position.y, cornerOne.position.y, cornerTwo.position.y), transform.position.z);


            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.P))
            {
                InitialClick();
                mouseDownTime += Time.deltaTime;
            }

            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.P))
            {
                mouseDownTime += Time.deltaTime;

                if (mouseDownTime > longClickThreshold)
                {
                    hoveredInteractable.OnLongClick();
                }
            }

            if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.P))
            {
                hoveredInteractable.OnShortClick();
                mouseDownTime = 0;
            }
        }

    }

    private void InitialClick()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Physics.Raycast(ray, out RaycastHit info);
        if(info.collider != null)
        {
            hoveredInteractable = info.collider.GetComponent<IScreenInteractable>();
            hoveredInteractable.OnInitClick();
        }
    }
    public void EnableMouse()
    {
        mouseEnabled = true;
    }
    public void DisableMouse()
    {
        mouseEnabled = false;
    }
    
}
