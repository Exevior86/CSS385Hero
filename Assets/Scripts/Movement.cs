using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Plane;
    public float enemySpeed = 10f;
    private int shotCount = 4;
    private GameController gameController = null;
    private GameObject[] waypoints;
    Vector3 direction = Vector3.zero;
    int counter;
    private const float kRotationSpeed = 1;

    // Update is called once per frame
    private void Start()
    {
        counter = Random.Range(0, 6);

        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Debug.Assert(gameController != null);
        waypoints = gameController.getWayPoints();

        SetToRandomLocation();

        direction = waypoints[counter].transform.position - transform.position;
        direction = direction.normalized;
        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * enemySpeed, direction.y * enemySpeed);
    }


    void Update()
    {
        Vector3 newDirection = (waypoints[counter].transform.position - transform.position).normalized;

        direction = Vector3.Lerp(direction, newDirection, Time.deltaTime * kRotationSpeed);

        GetComponent<Rigidbody2D>().velocity = new Vector2(direction.x * enemySpeed, direction.y * enemySpeed);
        transform.up = direction;
    }

    private void SetToRandomLocation()
    {
        //Vector3 position = gameObject.transform.position;

        //int ranX = Random.Range(-15, 16);
        //int ranY = Random.Range(-15, 16);

        //transform.position = new Vector3(position.x + ranX, position.y + ranY, position.z);

        // appoximately the world area. Should be a systematically-computed static somewhere
        int newX = Random.Range(-50, 50);
        int newY = Random.Range(-30, 30);

        transform.position = new Vector3(newX, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            shotCount--;
            this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, .25f * shotCount);

            if (shotCount <= 0)
            {
                SetToRandomLocation();
                shotCount = 4;
                this.GetComponent<Renderer>().material.color = new Color(1.0f, 1.0f, 1.0f, .25f * shotCount);
                gameController.IncrementNumEnemiesDestroyed();
            }
        }
        else if (collision.gameObject.CompareTag("Waypoint"))
        {
            if (collision.gameObject == waypoints[counter])
            {
                if (!gameController.GetRandomWaypoints())
                {
                    counter++;
                    if (counter > 5)
                    {
                        counter = 0;
                    }
                }
                else
                {
                    int ran = Random.Range(0, 6);
                    if (ran == counter)
                    {
                        ran--;
                        if (ran < 0)
                        {
                            ran = 5;
                        }
                    }

                    counter = ran;
                }
            }

                   
        }

        else if (collision.gameObject.CompareTag("Player"))
        {
            gameController.IncrementNumEnemiesTouched();
            SetToRandomLocation();
        }
    }

    void RespawnPlane()
    {

    }

    
}
