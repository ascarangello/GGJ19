﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class InventoryItem : ScriptableObject
{
    public Sprite sprite;
    public int numLeft;
    public GameObject player;

    public void PlaceItem()
    {
        // Does nothing because this method needs to be overridden by child classes
    }

    public void RemoveItem() {
        if (this.numLeft <= 1)
        {
            Destroy(this);
        } else
        {
            this.numLeft--;
        }
    }
}