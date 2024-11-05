using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    [SerializeField] GameObject interactionMessage;
    [SerializeField] TextMeshProUGUI interactionMessageText;

    public static InteractionHandler _instance;
    
    public Interactable objectAwaitingInteraction; // Object player is currently looking at and MAY interact with
    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInteractMessage(bool show, string message = "") // Show or hide interact message. Optional message parameter
    {
        interactionMessageText.text = message;
        interactionMessage.SetActive(show);
    }


}
