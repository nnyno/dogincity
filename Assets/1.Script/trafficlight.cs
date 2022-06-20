using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficlight : MonoBehaviour
{
    public float delayTime = 5;
    public bool redlight = true;
    public bool isDelay = false;
    public BoxCollider box;
    //public GameObject greenlights, redlights;

    void Update()
    {
        if(!isDelay)
        {
            isDelay = true;    
            StartCoroutine(trafficcolor());
        }
    }

    IEnumerator trafficcolor()
    {
        yield return new WaitForSecondsRealtime(delayTime);
        isDelay = false;
        if(redlight == true)
        {
            redlight = false;
            box.enabled = false;
            //greenlights.SetActive(true);
            //redlights.SetActive(false);
        }
        else
        {
            redlight = true;
            box.enabled = true;
            //greenlights.SetActive(false);
            //redlights.SetActive(true);
        }
    }
}