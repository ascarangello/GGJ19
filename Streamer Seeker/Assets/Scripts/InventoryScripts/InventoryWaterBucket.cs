using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryWaterBucket : InventoryItem
{

    public GameObject waterBucket;

    public override void PlaceItem()
    {
        Debug.Log("Placing item");
        GameObject player = GameObject.FindGameObjectWithTag("Streamer");
        if (player.GetComponent<PlayerController>().OnDoorWindow() && this.numLeft > 0 
            && !player.GetComponent<PlayerController>().IsOnTrap())
        {
            GameObject clone;
            clone = Instantiate(this.waterBucket, player.transform.localPosition, player.transform.localRotation);
            this.numLeft--;
            Debug.Log("WB Placed");
        }
    }
}
