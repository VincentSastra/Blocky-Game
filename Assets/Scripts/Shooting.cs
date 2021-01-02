using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Bullet bulletPrefab;
    public float velocity = 20f;

    void OnMouseDown() {
        Shoot();
    }

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = (new Vector2((2 * Input.mousePosition.x - Screen.width), (2 * Input.mousePosition.y - Screen.height))).normalized * velocity;
    }
}
