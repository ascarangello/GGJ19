using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewerInfo : MonoBehaviour
{
    public string viewerName;
    public int health;
    public string chosenWindow;
    public bool hasWon;
    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        viewerName = gameObject.name;
        chosenWindow = "NA";
        hasWon = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
