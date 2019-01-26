using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostAnimator : MonoBehaviour
{
    float dirx, diry;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        print("test");
        anim.speed = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dirx = Input.GetAxis("Horizontal");
        diry = Input.GetAxis("Vertical");

        if (dirx >= 0.1 && diry == 0){
            anim.speed = 1;
            anim.SetInteger("Direction", 3);
        }
        else if (dirx == 0 && diry >= 0.1)
        {
            anim.speed = 1;
            anim.SetInteger("Direction", 1);
        }
        else if (dirx <= -0.1 && diry == 0)
        {
            anim.speed = 1;
            anim.SetInteger("Direction", 2);
        }
        else if (dirx == 0 && diry <= -0.1)
        {
            anim.speed = 1;
            anim.SetInteger("Direction", 4);
        }
        else if (dirx == 0 && diry == 0)
        {
            anim.SetInteger("Direction", 0);
            anim.speed = 0f;
        }
    }
}
