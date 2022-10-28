using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flash : MonoBehaviour
{
    public maps maps;
    public Image imageGrid;
    public GameObject mapbackground;
    public bool mapon = false;

    void Start()
    {
        maps = GameObject.Find("Map Group").GetComponent<maps>();
    }

    void Update()
    {
        if(maps.mapscount == 9)
        {
            if(mapbackground.gameObject.activeSelf == true)
            {
                if(mapon == false)
                {
                    StartCoroutine("EMarkerGrid");
                }
                mapon = true;
            }
            else
            {
                mapon = false;
            }
        }

    }
    public IEnumerator EMarkerGrid()
    {
        while(true)
        {
            this.imageGrid.gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(0.5f);
            this.imageGrid.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(0.5f);
        }
    }
}
