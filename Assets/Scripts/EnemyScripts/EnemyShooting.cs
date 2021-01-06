using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyShooting : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public Bullet bulletPrefab;
    public float velocity = 20f;
    public Transform target;

    void Start()
    {
        Shoot(); 
    }
    
    // A Task that is done after a timed delay
    private IEnumerator ExecuteAfterTime(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task();
    }

    void Shoot()
    {
        Bullet bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = (target.position - rb.transform.position).normalized * velocity;
        bullet.gameObject.layer = bulletSpawnPoint.gameObject.layer;
        IEnumerator removerTask = ExecuteAfterTime(3, () => {
            Shoot();
            });
        StartCoroutine(removerTask);
    }
}
