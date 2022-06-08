using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Changemap : MonoBehaviour
{
    public stress stress = null;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Simple_Door")
        {
            LoadingSceneManager.LoadScene("SampleScene");
        }
    }

    void Update()
    {
        if(stress.Stress == 0)
        {
            LoadingSceneManager.LoadScene("Interface");
        }   
    }

}

