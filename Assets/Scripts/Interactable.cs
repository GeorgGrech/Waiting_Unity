using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] protected string interactMessage;
    [SerializeField] protected bool awaitingInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void AwaitInteraction()
    {
        Debug.Log("Player may interact");
    }

    protected void CancelAwaitInteraction()
    {
        Debug.Log("Player may no longer interact");
    }

    protected void Interact()
    {
        Debug.Log("Interacting");
    }
}
