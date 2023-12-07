using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform BulletSpawnPoint;
    public float fireInterval = 3.0f; // Adjust the fire interval to 3 seconds

    private float lastFireTime;

    void Update()
    {
        // Check if the space bar is pressed and enough time has passed since the last shot
        if (Keyboard.current.spaceKey.wasPressedThisFrame && Time.time - lastFireTime > fireInterval)
        {
            // Shoot a bullet
            ShootBullet();
            lastFireTime = Time.time;
        }
    }

    void ShootBullet()
    {
        // Instantiate a new bullet at the spawn point
        GameObject bullet = Instantiate(bulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);

        // Set the mass of the bullet
        bullet.GetComponent<Rigidbody>().mass = bullet.GetComponent<BulletCollision>().bulletMass;

        // Shoot the bullet forward
        bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * bullet.GetComponent<BulletCollision>().bulletSpeed;
    }
}
