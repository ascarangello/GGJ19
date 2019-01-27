using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gettingInside : MonoBehaviour
{
    public GameObject entrance;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Viewer")
        {
            Debug.Log("Here");
            collision.transform.position = entrance.transform.position;
        }
    }
}
