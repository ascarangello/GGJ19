﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryController : MonoBehaviour
{
    public Image[] images = new Image[numItemSlots];
    public InventoryItem[] items = new InventoryItem[numItemSlots];
    public Text[] itemcount = new Text[numItemSlots];

    public const int numItemSlots = 4;

    public void Start()
    {
        for (int i = 0; i < numItemSlots; i++)
        {
            this.itemcount[i].text = this.items[i].numLeft.ToString();
        }
    }

    public void UseItem() {
        // Water Bucket
        if (Input.GetKeyDown("Alpha1"))
        {
            if (this.items[0].numLeft == 0)
            {

            }
            else
            {
                this.items[0].PlaceItem();
                this.itemcount[0].text = this.items[0].numLeft.ToString();
                if (this.items[0].numLeft == 0)
                {
                    this.itemcount[0].text = "0";
                    this.images[0].sprite = null;
                    this.images[0].enabled = false;
                }
            }
        }
        // Mentos Diet Coke Rocket
        else if (Input.GetKeyDown("Alpha2"))
        {
            if (this.items[1].numLeft == 0)
            {

            }
            else
            {
                this.items[1].PlaceItem();
                this.itemcount[1].text = this.items[1].numLeft.ToString();
                if (this.items[1].numLeft == 0)
                {
                    this.itemcount[0].text = "1";
                    this.images[1].sprite = null;
                    this.images[1].enabled = false;
                }
            }
        }
        // Speakers
        else if (Input.GetKeyDown("Alpha3"))
        {
            if (this.items[2].numLeft == 0)
            {

            }
            else
            {
                this.items[2].PlaceItem();
                this.itemcount[2].text = this.items[2].numLeft.ToString();
                if (this.items[2].numLeft == 0)
                {
                    this.itemcount[0].text = "2";
                    this.images[2].sprite = null;
                    this.images[2].enabled = false;
                }
            }

        }
        // Axe
        else if (Input.GetKeyDown("Alpha4"))
        {
            if (this.items[2].numLeft == 0)
            {

            }
            else
            {
                this.items[3].PlaceItem();
                this.itemcount[3].text = this.items[3].numLeft.ToString();
                if (this.items[3].numLeft == 0)
                {
                    this.itemcount[0].text = "3";
                    this.images[3].sprite = null;
                    this.images[3].enabled = false;
                }
            }
        }
    }
}
