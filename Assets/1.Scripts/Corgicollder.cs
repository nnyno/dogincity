﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Corgicollder : MonoBehaviour
{
    public GameObject nearObject;
    public int nearfood;
    public bool park = false;
    public bool market = false;
    public bool printflyers = false;
    public bool home = false;

    void OnTriggerStay(Collider other) 
    {

        if(other.tag == "apple")
        {
            nearfood = 1;
            nearObject = other.gameObject;
        }
        else if (other.tag == "banana")
        {
            nearfood = 2;
            nearObject = other.gameObject;
        }
        else if(other.tag == "bread")
        {
            nearfood = 3;
            nearObject = other.gameObject;
        }
        else if(other.tag == "pepper")
        {
            nearfood = 4;
            nearObject = other.gameObject;
        }
        else if(other.tag == "leek")
        {
            nearfood = 5;
            nearObject = other.gameObject;
        }
        else if(other.tag == "melon")
        {
            nearfood = 6;
            nearObject = other.gameObject;
        }
        else if(other.tag == "cheese")
        {
            nearfood = 7;
            nearObject = other.gameObject;
        }
        else if(other.tag == "tomato")
        {
            nearfood = 8;
            nearObject = other.gameObject;
        }
        else if(other.tag == "asparagus")
        {
            nearfood = 9;
            nearObject = other.gameObject;
        }
        else if(other.tag == "garlic")
        {
            nearfood = 10;
            nearObject = other.gameObject;
        }
        else if(other.tag == "beef")
        {
            nearfood = 11;
            nearObject = other.gameObject;
        }
        else if(other.tag == "bone beef")
        {
            nearfood = 12;
            nearObject = other.gameObject;
        }
        else if(other.tag == "orange")
        {
            nearfood = 13;
            nearObject = other.gameObject;
        }
        else if(other.tag == "artichoke")
        {
            nearfood = 14;
            nearObject = other.gameObject;
        }
        else if(other.tag == "perry")
        {
            nearfood = 15;
            nearObject = other.gameObject;
        }
        else if(other.tag == "carots")
        {
            nearfood = 16;
            nearObject = other.gameObject;
        }
        else if(other.tag == "salad")
        {
            nearfood = 17;
            nearObject = other.gameObject;
        }
        else if(other.tag == "chicken")
        {
            nearfood = 18;
            nearObject = other.gameObject;
        }
        else if(other.tag == "burger")
        {
            nearfood = 19;
            nearObject = other.gameObject;
        }
        else if(other.tag == "hotdog")
        {
            nearfood = 20;
            nearObject = other.gameObject;
        }
        else if(other.tag == "park")
        {
            park = true;
        }
        else if(other.tag == "market")
        {
            market = true;
        }
        else if(other.tag == "printflyers")
        {
            printflyers = true;
        }
        else if(other.tag == "home")
        {
            home = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "food")
        {
            nearfood = 0;
            nearObject = null;
        }
        else if(other.tag == "park")
        {
            park = false;
        }
        else if(other.tag == "market")
        {
            market = false;
        }
        else if(other.tag == "printflyers")
        {
            printflyers = false;
        }
    }
}
