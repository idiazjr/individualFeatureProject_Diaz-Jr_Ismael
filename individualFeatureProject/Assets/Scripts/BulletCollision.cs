using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public float bulletMass = 2f;

    private void Start()
    {
        StartCoroutine(BulletDespawn());
    }
    void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet when it collides with another object
        Destroy(gameObject);
    }
    IEnumerator BulletDespawn()
    {
            // Wait for the specified interval before destroying object
            yield return new WaitForSeconds(0.5f);

        //destroy bullet
        Destroy(gameObject);

    }
}
