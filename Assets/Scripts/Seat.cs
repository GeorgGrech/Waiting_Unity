using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Seat : MonoBehaviour
{
    public void AwaitInteraction()
    {
        Debug.Log("Press E to sit");
    }

    public void Interact()
    {
        Debug.Log("Player Sitting");
    }
}
