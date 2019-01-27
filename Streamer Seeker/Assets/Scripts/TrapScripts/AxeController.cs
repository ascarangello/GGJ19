using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    private List<GameObject> targets;
    private float sprayTime = 1;
    private bool spraying = false;
    private Animator anim;

    public void Start()
    {
        this.targets = new List<GameObject>();
        Physics.queriesHitTriggers = true;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        if (spraying)
        {
            foreach (GameObject go in this.targets)
            {
                go.GetComponent<viewerInfo>().dealDamage(10);
            }
            sprayTime -= Time.deltaTime;
        }
        if (sprayTime <= 0)
        {
            spraying = false;
            sprayTime = 1;
            anim.SetTrigger("NoAxe");
        }
    }

    public void OnMouseDown()
    {
        this.spraying = true;
        anim.SetTrigger("Axe");
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Viewer") && !targets.Contains(collision.GetComponent<GameObject>()))
        {
            this.targets.Add(collision.GetComponent<GameObject>());
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Viewer") && targets.Contains(collision.GetComponent<GameObject>()))
        {
            this.targets.Remove(collision.GetComponent<GameObject>());
        }
    }

    public void SprayFinish()
    {
        //get the viewer data for each game object in targets and do what needs to be done.

        this.targets.Clear();
        Destroy(this);

    }
}
