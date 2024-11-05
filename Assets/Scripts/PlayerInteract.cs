using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteract : MonoBehaviour
{
    private PlayerInput input;
    private InputAction interactAction;
    private Camera mainCam;

    [SerializeField] private float interactDistance; // Distance player can interact with objects

    [SerializeField] private Transform currentObservedObject;
    // Start is called before the first frame update
    void Start()
    {
        mainCam = Camera.main;

        input = GetComponent<PlayerInput>();
        interactAction = input.actions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (!mainCam) return; // Let mainCam be assigned first

        Ray ray = new(mainCam.transform.position, mainCam.transform.forward); // In front of camera
        bool hit = Physics.Raycast(ray, out RaycastHit hitInfo, interactDistance); // If object within distance

        if (!hit || !hitInfo.transform.CompareTag("Interactable")) // No object hit or object hit is not interactable
        {
            if(currentObservedObject) currentObservedObject.gameObject.SendMessage("CancelAwaitInteraction", SendMessageOptions.DontRequireReceiver); // Object is no longer observed. Cancel interaction message
            currentObservedObject = null; // "Forget" the object previously observed
            return;
        }

        // Interaction possible and interact action pressed
        if (interactAction.WasPressedThisFrame())
        {
            hitInfo.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); // Find object's corresponding Interact method
        }

        // If interact action has not been pressed, check if this is previously observed object to avoid duplicate AwaitInteraction Method

        if (currentObservedObject == hitInfo.transform) return; // Object has been previously observed. Ignore.

        currentObservedObject = hitInfo.transform;

        currentObservedObject.gameObject.SendMessage("AwaitInteraction", SendMessageOptions.DontRequireReceiver); // Find object's corresponding AwaitInteraction method

        //return;
    }
}
