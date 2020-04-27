using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Plane;
    public int shotCount = 3;
    public float enemySpeed = 10f;
    public static GameObject[] waypoints;
    Vector3 direction = Vector3.zero;
    int counter;
    public bool random = false;

    // Update is called once per frame
    private void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        counter = Random.Range(0, 6);

        direction = waypoints[counter].transform.position - transform.position;
        direction = direction.normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * enemySpeed, direction.y * enemySpeed);
    }

    void Update()
    {
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * enemySpeed, direction.y * enemySpeed);
        transform.up = direction;
        if (Input.GetKeyDown(KeyCode.J))
        {
            random = !random;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            Vector3 position = gameObject.transform.position;
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
        if (collision.gameObject.CompareTag("Waypoint") && random == false)
        {
            counter--;
            if (counter < 0)
            {
                counter = 5;
            }
            direction = waypoints[counter].transform.position - transform.position;
            direction = direction.normalized;           
        }
        else
        {
            int ran = Random.Range(0, 6);
            if(ran == counter)
            {
                ran--;
                if (ran < 0)
                {
                    ran = 5;
                }
            }

            counter = ran;

            direction = waypoints[counter].transform.position - transform.position;
            direction = direction.normalized;
        }
    }

    
}
