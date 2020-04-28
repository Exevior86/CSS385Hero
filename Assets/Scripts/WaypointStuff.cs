using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaypointStuff : MonoBehaviour
{
    private int shotCount = 4;
    Vector3 position;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            shotCount--;
            this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, .25f * shotCount);

            if (shotCount <= 0)
            {
                int ranX = Random.Range(-15, 16);
                int ranY = Random.Range(-15, 16);

                transform.position = new Vector3(position.x + ranX, position.y + ranY, position.z);
                shotCount = 4;
                this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, .25f * shotCount);
            }
        }
        if(collision.gameObject.CompareTag("East"))
        {
            if(transform.position.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 5, transform.position.y, transform.position.z); ;
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 5, transform.position.y, transform.position.z); ;
            }
        }
        if(collision.gameObject.CompareTag("North"))
        {
            if (transform.position.y < 0)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z); ;
            }
            else
            {
                transform.position = new Vector3(transform.position.x - 5, transform.position.y - 5, transform.position.z); ;
            }
        }
    }
}
