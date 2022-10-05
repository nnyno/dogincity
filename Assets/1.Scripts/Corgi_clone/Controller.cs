using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject[] maps;
    public int cnt;
    public GameObject[] clone;
    Animator _animator;

    void Start()
    {

        cnt = UnityEngine.Random.Range(0, 4);
        _animator = clone[cnt].GetComponent<Animator>();
        maps[cnt].SetActive(true);
        _animator.SetLayerWeight(1, 1f);

        _animator.SetTrigger("New Trigger");

        if(cnt == 0)
        {

        }
        else if(cnt == 1)
        {

        }
        else if(cnt == 2)
        {

        }
        else
        {

        }
        
    }

    void Update()
    {
        
    }
}
