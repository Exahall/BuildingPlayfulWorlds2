using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Singleton script that fires a raycast from the center of the screen, to where the player is looking.
// With this, it detects what the player is looking at, and allows clicking on them.
public class InputRaycaster : MonoBehaviour
{
    // The singleton reference
    protected static InputRaycaster _instance;
    // The getter for the singleton. If the reference has not been set yet, find it first!
    public static InputRaycaster instance
    {
        get
        {
            if (_instance == null) _instance = GameObject.FindObjectOfType<InputRaycaster>();
            return _instance;
        }
    }

    // Layers that can be hit by the raycast
    public LayerMask hitLayers;
    // Maximum distance to send raycasts at
    public float maxDistance;

    // Camera to cast raycasts at
    private Camera cam;
    // Interactable that is currently looked at
    public Interactable currentFocus;

    // Find the camera to raycast from
    private void Awake()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    // Every frame, send a raycast to look for interactables. If found, allow clicking on them.
    private void Update()
    {
        if (DiaryStateMachine.instance.currentPage != DiaryPage.none) return;

        Vector3 rayPoint = new Vector3(Screen.width / 2, Screen.height / 2);
        Ray ray = cam.ScreenPointToRay(rayPoint);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, hitLayers))
        {
            currentFocus = hit.collider.gameObject.GetComponent<Interactable>();
        }
        else
        {
            currentFocus = null;
        }

        if (currentFocus != null && Input.GetMouseButtonDown(0))
        {
            currentFocus.Interact();
        }
    }

}
