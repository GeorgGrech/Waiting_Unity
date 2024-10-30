using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] Vector3 movementSpeed;

    void FixedUpdate()
    {
        transform.position += movementSpeed * Time.fixedDeltaTime;
    }
}
