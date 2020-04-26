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
    }
}
