using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scripton : MonoBehaviour
{
    public CameraMovement cm;
    public PlayerMovement pm;
    public GameObject cv = null;
    public GameObject tl = null;
    public GameObject corgi = null;
    public GameObject man = null;

    // Start is called before the first frame update
    void Start()
    {
        cm = GameObject.Find("Cameras").GetComponent<CameraMovement>();
        pm = GameObject.Find("Corgi_RM").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void scriptstart()
    {
        man.SetActive(true);
        corgi.SetActive(true);
        cm.enabled = true;
        pm.enabled = true;
        cv.SetActive(true);
        tl.SetActive(false);
    }
}
