using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySpeakers : InventoryItem
{

    public GameObject speaker;

    // Start is called before the first frame update
    void Start()
    {
        this.numLeft = 2;
    }

    public override void PlaceItem()
    {
        if (this.numLeft > 0 && !this.player.GetComponent<PlayerController>().OnDoorWindow() 
            && !this.player.GetComponent<PlayerController>().IsOnTrap())
        {
            GameObject clone;
            clone = Instantiate(this.speaker, this.player.transform.position, this.player.transform.rotation);
            clone.SetActive(false);
            this.numLeft--;
        }
    }
}
