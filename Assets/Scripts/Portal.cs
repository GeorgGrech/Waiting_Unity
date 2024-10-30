using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] Transform linkedPortal;
    private Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

    }

    private void OnTriggerStay(Collider other) // For efficiency, Portal is only functional when collision detected
    {
        if (other.CompareTag("Player") == false) // Only do if collision is player
        {
            return;
        }

        Vector3 playerOffsetPosition = transform.InverseTransformPoint(playerTransform.position); // Get local position in reference to this portal

        if (playerOffsetPosition.z > 0) // Check for difference. Negative difference indicates player has crossed portal and teleportation should occur
        {
            return;
        }

        Vector3 mirroredPlayerOffset = new( 
            -playerOffsetPosition.x,
            playerOffsetPosition.y,
            -playerOffsetPosition.z); // Calculate new local position with mirrored x and z

        Vector3 teleportPosition = linkedPortal.TransformPoint(mirroredPlayerOffset); // From calculated local position, now calculate world position in reference to linked portal

        //Debug.Log("Teleporting to : " + teleportPosition);

        playerTransform.position = teleportPosition; // Teleport player
        
    }
}
