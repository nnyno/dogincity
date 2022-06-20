using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colli : MonoBehaviour
{
    public bool waypoints = true;
    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("waypoint"))
        {
            waypoints = true;
        }
    }
}
