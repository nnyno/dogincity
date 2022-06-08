using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stressup : MonoBehaviour
{
    public stress stress = null;
    public BoxCollider door;

    void Update()
    {
        stress.Stress += Time.deltaTime*5f;
        if(stress.Stress >= 100)
        {
            door.enabled = true;
        }
    }
}
