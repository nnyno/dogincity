﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traffic : MonoBehaviour
{
    //public Move move = null;
    RaycastHit hit, hit2;
    public float distance = 3.0f;
    public float distance2 = 10.0f;

    void Update()
    {
        ray();
    }

    public void ray()
    {
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.forward * distance, Color.red);
        Debug.DrawRay(gameObject.transform.position,gameObject.transform.forward * distance2, Color.blue);
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit2, distance2))
        {
            if(hit2.transform.name == "trafficlight")
            {
                //move.speed = 0.05f;
                if(Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, distance))
                {
                    if(hit.transform.name == "trafficlight")
                    {
                        //move.speed = 0.0f;
                    }
                }
            }
        }
        else
        {
            //move.speed = 0.1f;
        }
    }
}
