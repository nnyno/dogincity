using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Changemap : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "Simple_Door")
        {
            LoadingSceneManager.LoadScene("SampleScene");
        }
    }

}

