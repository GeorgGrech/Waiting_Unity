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

        if (!hit) return; // Nothing hit

        if (!interactAction.WasPressedThisFrame()) // Interaction possible but interact action not pressed
        {
            hitInfo.transform.gameObject.SendMessage("AwaitInteraction", SendMessageOptions.DontRequireReceiver); // Find object's corresponding AwaitInteraction method
            return;
        }

        if (interactAction.WasPressedThisFrame()) // Interaction possible and interact action pressed
        {
            hitInfo.transform.gameObject.SendMessage("Interact", SendMessageOptions.DontRequireReceiver); // Find object's corresponding Interact method
            return;
        }

    }
}
