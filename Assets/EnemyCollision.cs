using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameObject prefabToSpawn;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int spawnPointX = Random.Range(-20, 20);
            int spawnPointY = Random.Range(-12, 12);
            GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
            newObject.transform.position.Set(spawnPointX, spawnPointY, 0);
            newObject.transform.eulerAngles = new Vector3(0f, 0f, Angle(transform.up));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }
    public static float Angle(Vector2 inputVector)
    {
        if (inputVector.x < 0) return (Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg * -1) - 360;
        else return -Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
    }
}
