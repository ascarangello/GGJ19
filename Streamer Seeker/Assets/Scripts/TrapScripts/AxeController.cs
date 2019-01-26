using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    public GameObject axe;
    private List<GameObject> targets;

    public void Start()
    {
        this.targets = new List<GameObject>();
        Physics.queriesHitTriggers = true;
    }

    public void MakeActive()
    {
        this.axe.SetActive(true);
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
        //get the viewer data for each game object in targets and do what needs to be done.
        this.targets.Clear();
        Destroy(this);
    }
}
