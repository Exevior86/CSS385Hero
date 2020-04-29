using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HeroBehavior : MonoBehaviour {

    public float mHeroSpeed = 20f;
    private const float kHeroRotateSpeed = 1f;

    public static float cooldown = .2f;
    public static float cooldownTimer = 0;

    public Vector2 pos;
    
    public GameObject prefabToSpawn;
    public float shootSpeed = 40f;
    public Vector2 shootDirection = new Vector2(1f, 1f);
    Vector3 direction = Vector2.up;

    Rigidbody2D myHeroBody;

    private GameController gameController = null;

    // Use this for initialization

    void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        Debug.Assert(gameController != null);

        myHeroBody = GetComponent<Rigidbody2D>();
        myHeroBody.velocity = direction;
    }
	
    // Update is called once per frame
    void Update () {
        UpdateMotion();
        ProcessEggSpwan();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("North"))
        {
            transform.up = new Vector3(transform.up.x, transform.up.y * -1, transform.up.z);
            direction.Set(direction.x, transform.up.y, direction.z);
        }
        if (collision.gameObject.CompareTag("East"))
        {
            transform.up = new Vector3(-transform.up.x, transform.up.y, transform.up.z);
            direction.Set(transform.up.x, direction.y, direction.z);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
    }

    private void HandleMouseMovement()
    {
        // cast to Vector2 to ignore z-component
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }


    private void HandleKeyMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (mHeroSpeed < 90)
                mHeroSpeed += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (mHeroSpeed > -90)
                mHeroSpeed -= 1;
        }
        if (Input.GetKey(KeyCode.P))
        {
            mHeroSpeed = 0;
        }
        transform.position += direction * mHeroSpeed * Time.deltaTime;
    }

    private void UpdateMotion() {

        if(Input.GetKeyDown(KeyCode.M))
        {
            gameController.ToggleUsingMouseControl();
        }

        // allow rotation change whether in mouse mode or key mode
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, 0, kHeroRotateSpeed);
            direction = transform.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 0, -kHeroRotateSpeed);
            direction = transform.up;
        }
        
        if(gameController.GetUsingMouseControl())
        {
            HandleMouseMovement();
        }
        else
        {
            HandleKeyMovement();
        }
    }
    
    private void ProcessEggSpwan() {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0)
        {
            Shoot();
            cooldownTimer = cooldown;
        }

    }

    public void ChangeCooldown(float cd)
    {
        cooldown = cd;
    }

    public void Shoot()
    {
        GameObject newObject = Instantiate<GameObject>(prefabToSpawn);
        newObject.transform.position = this.transform.position;
        newObject.transform.eulerAngles = new Vector3(0f, 0f, Angle(direction));

        Rigidbody2D rigidbody2D = newObject.GetComponent<Rigidbody2D>();

        if (rigidbody2D != null)
        {
            rigidbody2D.AddForce(transform.up * shootSpeed, ForceMode2D.Impulse);
        }
    }

    public static float Angle(Vector2 inputVector)
    {
        if (inputVector.x < 0) return (Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg * -1) - 360;
        else return -Mathf.Atan2(inputVector.x, inputVector.y) * Mathf.Rad2Deg;
    }
}
