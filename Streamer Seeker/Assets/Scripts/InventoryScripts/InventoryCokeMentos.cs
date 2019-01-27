﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCokeMentos : InventoryItem
{

    public GameObject cokeMentos;

    // Start is called before the first frame update
    void Start()
    {
        this.numLeft = 3;
    }

    public override void PlaceItem()
    {
        if (this.numLeft > 0 && !this.player.GetComponent<PlayerController>().OnDoorWindow()
            && !this.player.GetComponent<PlayerController>().IsOnTrap())
        {
            GameObject clone;
            clone = Instantiate(this.cokeMentos, this.player.transform.position, this.player.transform.rotation);
            clone.SetActive(false);
            this.numLeft--;
        }
    }
}