using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D body;
    Animator anmi;

    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;

    public float runSpeed = 10;
    public float bulletSpeed = 20;
    public GameObject bulletPrefab;
    public Transform spawnOffset;
    public string itemName = "NA";

    private float shootCooldown = 1;
    private bool canShoot;
    private bool inDoorWindow = false;
    private bool onTrap = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anmi = GetComponent<Animator>();
        canShoot = true;

    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if(!canShoot)
        {
            shootCooldown -= Time.deltaTime;
        }
        if(shootCooldown <= 0)
        {
            canShoot = true;
            shootCooldown = 1;
        }
        if(itemName == "Plunger")
        {

        }

    }

    void FixedUpdate()
    {   // Check for diagonal movement
        if (horizontal != 0 && vertical != 0)
        {
            body.velocity = new Vector2((horizontal * runSpeed) * moveLimiter, (vertical * runSpeed) * moveLimiter); // move at less speed 
        }
        // if not moving diagonally
        else
        { 
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed); // move at normal speed
        }
        transform.position = body.transform.position;
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            foreach (GameObject oldBullet in GameObject.FindGameObjectsWithTag("Projectile"))
            {
                GameObject.Destroy(oldBullet);
            }
            GameObject proj = Object.Instantiate(bulletPrefab, spawnOffset.transform.position, spawnOffset.transform.rotation);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * (spawnOffset.transform.eulerAngles.z + 90)),
                                                                    Mathf.Sin(Mathf.Deg2Rad * (spawnOffset.transform.eulerAngles.z + 90))) * bulletSpeed;
            canShoot = false;

        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("door") || collision.CompareTag("window"))
        {
            this.inDoorWindow = true;
        }
        if (collision.CompareTag("trap"))
        {
            this.onTrap = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("door") || collision.CompareTag("window"))
        {
            this.inDoorWindow = false;
        }
        if (collision.CompareTag("trap"))
        {
            this.onTrap = true;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.E) && collision.gameObject.CompareTag("Item"))
        {
            itemName = collision.gameObject.name;
            collision.gameObject.SetActive(false);
        }
    }

    public bool OnDoorWindow()
    {
        return this.inDoorWindow;
    }

    public bool IsOnTrap()
    {
        return this.onTrap;
    }
}
