using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeController : MonoBehaviour
{
    private List<GameObject> targets;
    private float sprayTime = 1;
    private bool spraying = false;

    public void Start()
    {
        this.targets = new List<GameObject>();
        Physics.queriesHitTriggers = true;
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
        }
    }

    public void OnMouseDown()
    {
        CircleCollider2D cc = this.gameObject.AddComponent<CircleCollider2D>();
        cc.offset = new Vector2(0, 0);
        cc.radius = 10;
        this.spraying = true;
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
