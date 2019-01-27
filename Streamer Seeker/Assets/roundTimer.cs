using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundTimer : MonoBehaviour
{
    public float roundPrep = 5;
    public bool roundStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (roundPrep > 0 && !roundStarted)
        {
            Debug.Log(Mathf.RoundToInt(roundPrep));
            roundPrep -= Time.deltaTime;
        }
        else if (roundPrep <= 0 && !roundStarted)
        {
            roundStarted = true;
            Debug.Log("did it");
        }

    }
}
