using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventorySpeakers : InventoryItem
{

    public GameObject speaker;

    public override void PlaceItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Streamer");
        if (this.numLeft > 0 && !player.GetComponent<PlayerController>().OnDoorWindow() 
            && !player.GetComponent<PlayerController>().IsOnTrap())
        {
            GameObject clone;
            clone = Instantiate(this.speaker, player.transform.position, player.transform.rotation);
            this.numLeft--;
        }
    }
}
