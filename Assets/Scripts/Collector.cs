using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Enemy") || collider.CompareTag("Player"))
        {
            //Destroy(gameObject)  === destroy obj attached the collision
            //Destroy(collider.gameObject) === destroy obj the collision collides with
            Destroy(collider.gameObject);
        }
    }
}
