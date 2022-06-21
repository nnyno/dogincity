using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stressup : MonoBehaviour
{
    public stress stress = null;
    public BoxCollider door;
    public bool up = false;

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
            door.enabled = true;
        }
    }

    void stressup()
    {
        up = true;
    }
}
