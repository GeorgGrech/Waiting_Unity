using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageCanvas : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField] float scaleResize;
    void Update()
    {
        if (gameObject.activeSelf) // Only update if should be visible to player
        {
            transform.rotation = Camera.main.transform.rotation;

            float dynamicScale = Vector3.Distance(transform.position, Camera.main.transform.position) * scaleResize;
            transform.localScale = new Vector3(dynamicScale, dynamicScale, 1);
        }
    }
}
