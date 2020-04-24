using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollision : MonoBehaviour
{
    float spawnTime;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("North") || collision.gameObject.CompareTag("South")
            || collision.gameObject.CompareTag("East") || collision.gameObject.CompareTag("West"))
        {
            Destroy(gameObject);
        }
    }
}