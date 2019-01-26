using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBucketController : MonoBehaviour
{
    public GameObject wb;
    private List<GameObject> targets;
    private int delay;

    public void Start()
    {
        this.targets = new List<GameObject>();
        this.delay = 0;
    }

    public void MakeActive()
    {
        this.wb.SetActive(true);
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
        //get the viewer data for each game object in targets and call the deal damage method.
        this.targets.Clear();
    }
}
