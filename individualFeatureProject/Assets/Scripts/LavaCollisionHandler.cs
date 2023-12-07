using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaCollisionHandler : MonoBehaviour
{
    void Start()
    {
        // Subscribe to the collision event
        GetComponent<Rigidbody>().collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the lava has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Destroy the lava object
            Destroy(gameObject);
        }
    }
}
