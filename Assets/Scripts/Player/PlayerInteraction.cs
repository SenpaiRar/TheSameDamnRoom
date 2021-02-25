using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera playerCamera;
    public TMP_Text interactionText;
    public UnityEvent OnInteractEvent = new UnityEvent();


    private bool TextRoutine;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            InteractWithObject();
        }
    }

    void InteractWithObject()
    {
       
        RaycastHit thisHit;

        Physics.Raycast(playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f)), out thisHit, 2);
        Debug.Log(thisHit.collider.name);
        thisHit.collider.GetComponent<Interactable>().Interact();
        interactionText.text = thisHit.collider.GetComponent<Interactable>().InteractText();
        if (!interactionText.isActiveAndEnabled)
        {
            StartCoroutine(ShowText());
        }
   
    }

    IEnumerator ShowText()
    {
        interactionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);
        interactionText.gameObject.SetActive(false);
    }
}
