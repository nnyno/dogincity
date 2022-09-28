using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Random_market : MonoBehaviour
{
    public Transform[] spawnPosArray;
    public GameObject slicedMap;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(slicedMap, spawnPosArray[Random.Range(0, 10)]);
    }
}
