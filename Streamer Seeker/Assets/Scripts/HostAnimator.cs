using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostAnimator : MonoBehaviour
{
    private  float dirx, diry;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.speed = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        dirx = Input.GetAxis("Horizontal");
        diry = Input.GetAxis("Vertical");

        anim.SetFloat("XPos", dirx);
        anim.SetFloat("YPos", diry);

        if (Input.GetKeyDown(KeyCode.Space)){
            anim.SetTrigger("Hit");
        }
    }
}
