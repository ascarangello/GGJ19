using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    float horizontal;
    float vertical;
    float moveLimiter = 0.7f;
    public float runSpeed = 10;
    public float bulletSpeed = 20;
    public GameObject bulletPrefab;
    public Transform spawnOffset;
    private float shootCooldown = 1;
    private bool canShoot;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
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
        //Set rotations
        if (vertical > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (vertical < 0) 
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if(horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if(horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        transform.position = body.transform.position;
        if(Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            foreach(GameObject oldBullet in GameObject.FindGameObjectsWithTag("Projectile"))
            {
                GameObject.Destroy(oldBullet);
            }
            GameObject proj = Object.Instantiate(bulletPrefab, spawnOffset.transform.position, spawnOffset.transform.rotation);
            proj.GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(Mathf.Deg2Rad * (transform.eulerAngles.z + 90)),
                                                                    Mathf.Sin(Mathf.Deg2Rad * (transform.eulerAngles.z + 90))) * bulletSpeed;
            canShoot = false;

        }
    }
}
