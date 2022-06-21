using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stressup : MonoBehaviour
{
    public stress stress = null;
    public BoxCollider doorbox;
    public bool up = false;
    public Animator dooranim;

    void Start()
    {
        Invoke("stressup", 26);
    }
    void Update()
    {
        if(up == true)
        {
            stress.Stress += Time.deltaTime*5f;
        }   
        if(stress.Stress >= 100)
        {
            doorbox.enabled = true;
            dooranim.enabled = true;
        }
    }

    void stressup()
    {
        up = true;
    }
}
