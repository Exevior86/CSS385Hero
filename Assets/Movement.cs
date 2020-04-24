using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float enemySpeed = 10f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * enemySpeed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("North"))
        {
            transform.Rotate(0, 0, -90);
        }
        if (collision.gameObject.CompareTag("South"))
        {
            transform.Rotate(0, 0, -90);
        }
        if (collision.gameObject.CompareTag("East"))
        {
            transform.Rotate(0, 0, -90);
        }
        if (collision.gameObject.CompareTag("West"))
        {
            transform.Rotate(0, 0, -90);
        }
    }

}
