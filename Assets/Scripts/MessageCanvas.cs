using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCanvas : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] float globalScale;
    void Update()
    {
        if (gameObject.activeSelf) // Only update if should be visible to player
        {
            transform.rotation = Camera.main.transform.rotation;
        }
    }
}
