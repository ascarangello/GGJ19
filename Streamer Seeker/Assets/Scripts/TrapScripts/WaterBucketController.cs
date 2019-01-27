using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketController : MonoBehaviour
{
    private List<GameObject> targets;
    private int delay;
    private Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>();
        this.targets = new List<GameObject>();
        this.delay = 0;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Viewer") && delay == 0)
        {
            Pour();
            delay++;
        } else if (collision.CompareTag("Viewer") && delay > 0 && delay < 10)
        {
            delay++;
        } else if (collision.CompareTag("Viewer"))
        {
            delay = 0;
        }
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

    public void Pour()
    {
        anim.SetTrigger("Bucket");
        Debug.Log("Pouring");
        foreach (GameObject go in this.targets)
        {
            go.GetComponent<viewerInfo>().dealDamage(10);
        }
        this.targets.Clear();
    }
}
