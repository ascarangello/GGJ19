using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CokeMentosController : MonoBehaviour
{
    private List<GameObject> targets;

    private Animator anim;

    public void Start()
    {
        this.targets = new List<GameObject>();
        anim = GetComponent<Animator>();
        Physics.queriesHitTriggers = true;
    }

    public void OnMouseDown()
    {
        Blast();
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

    public void Blast()
    {
        print("Test");
        anim.SetTrigger("Coke");
        foreach (GameObject go in this.targets)
        {
            go.GetComponent<viewerInfo>().dealDamage(10);
        }
        this.targets.Clear();
        Destroy(this);
    }
}
