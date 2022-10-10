using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class maps : MonoBehaviour
{
    public PlayerMovement pm = null;
    public Questmanager qm = null;
    public GameObject[] mapspiece;
    public GameObject hometag;
    public int mapscount = 0;
    int i;



    void Update()
    {
        mapscount = pm.mapscount;
        if(mapscount != 0)
        {
            for(i = 0; i < mapscount; i++)
            {
                mapspiece[i].SetActive(true);
                if(mapscount == 9)
                {
                    hometag.SetActive(true);
                    qm.home.enabled = false;
                    qm.home2.enabled = false;
                }
            }
        }
        
    }

}
