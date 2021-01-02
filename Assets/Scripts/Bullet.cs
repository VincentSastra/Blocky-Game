using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // This is the task of our coroutine, removing the spelldata in 5 seconds
        IEnumerator removerTask = ExecuteAfterTime(5, () => {
            Destroy(gameObject);
            });

        StartCoroutine(removerTask);
        
    }

        // A Task that is done after a timed delay
    private IEnumerator ExecuteAfterTime(float time, Action task)
    {
        yield return new WaitForSeconds(time);
        task();
    }

    // Happens on collision
    void OnCollisionEnter(Collision Other)
    {
        Destroy(gameObject)
    }
}
