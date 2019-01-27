using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnEnemy : MonoBehaviour
{


    public float spawnTime = 3f;
    private string playerName;
    private int charRand;
    private Animator anmiCont;
    private string[] listOfNames =
    {
        "Lance Lynnnnnnn",
"Bobby BoBollia",
"Chip Witley",
"Death Grips",
"Elliot Scarangello",
"Nick Conig",
"Rattlesnake Jack",
"Sarai Legenblossom",
"Jeffery Jefferies",
"Gggirl 88",
"Seven Siegal",
"BIg Chungus",
"xxBony Boixx",
"Skacame beforeRaggae",
"Book Ska"
    };




    // Start is called before the first frame update
    void Start()
    {
        charRand = Random.Range(1, 5);
        anmiCont = GetComponent<Animator>();
        anmiCont.SetInteger("RandomAnimation", charRand);
        this.transform.position = new Vector3(-0.8f, -15.93f, -.031f);
        string chosenEntry = GetComponent<viewerInfo>().chosenWindow;
        if (chosenEntry == "NA")
        {
            int nameNum = Random.Range(1, listOfNames.Length);
            this.GetComponent<viewerInfo>().viewerName = listOfNames[nameNum];
            int randLetter = Random.Range(1, 3);
            if(randLetter == 1)
            {
                int randNum = Random.Range(1, 8);
                chosenEntry = "w" + randNum.ToString();
            }
            else
            {
                int randNum = Random.Range(1, 3);
                chosenEntry = "d" + randNum.ToString();
            }
        }
        this.GetComponent<AI_FIndingPath>().target = GameObject.Find(chosenEntry).transform;

    }

    // Update is called once per frame
    void Update()
    {
        



    }
}
