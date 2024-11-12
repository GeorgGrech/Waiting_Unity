using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    [SerializeField] protected GameObject messageCanvas;
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
        messageCanvas.SetActive(true);
    }

    protected void CancelAwaitInteraction()
    {
        Debug.Log("Player may no longer interact");
        messageCanvas.SetActive(false);
    }

    protected void Interact()
    {
        Debug.Log("Interacting");
    }
}
