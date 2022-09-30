using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maps : MonoBehaviour
{
    public PlayerMovement pm = null;
    public GameObject[] mapspiece;
    int mapscount = 0;
    int i;

    void Update()
    {
        mapscount = pm.mapscount;
        if(mapscount != 0)
        {
            for(i = 0; i < mapscount; i++)
            {
                mapspiece[i].SetActive(true);
            }
        }
    }
}
