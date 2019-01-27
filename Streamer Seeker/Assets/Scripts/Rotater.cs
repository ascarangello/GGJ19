using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    float horizontal;
    float vertical;
    // Start is called before the first frame update
    void Start()
    {
        
    }

	// Update is called once per frame

	void Update()
	{
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
	}
	void FixedUpdate()
    {
        if (vertical > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (vertical < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
        }
        else if (horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
        else if (horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }
}
