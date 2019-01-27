using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryCokeMentos : InventoryItem
{

    public GameObject cokeMentos;

    public override void PlaceItem()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Streamer");
        if (this.numLeft > 0 && !player.GetComponent<PlayerController>().OnDoorWindow()
            && !player.GetComponent<PlayerController>().IsOnTrap())
        {
            GameObject clone;
            clone = Instantiate(this.cokeMentos, player.transform.position, player.transform.rotation);
            this.numLeft--;
        }
    }
}
