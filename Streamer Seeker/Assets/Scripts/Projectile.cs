using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collision collision)
    {
        if(collision.gameObject.tag == "Viewer")
        {
            Destroy(collision.gameObject);
        }
    }
}
