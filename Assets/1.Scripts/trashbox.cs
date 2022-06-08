using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trashbox : MonoBehaviour
{
    public difficulty difficulty = null;
    public GameObject[] trashfood;
    public int trashfoodIndexs = 0;
    public int trashran = 0;
    public GameObject CreatePoint;


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "land")
        {
            trashran =  UnityEngine.Random.Range(0, 5);
            if(trashran == 4)
            {
                trashfoodIndexs =  UnityEngine.Random.Range(0, 5);
                Instantiate(trashfood[trashfoodIndexs], CreatePoint.transform.position, Quaternion.identity);
            }
            difficulty.difscore += 0.2f;
        }
    }
}
