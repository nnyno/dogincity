using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surprise : MonoBehaviour
{
    public difficulty difficulty = null;
    Animator _animator;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(difficulty.surprise == true)
        {
            _animator.SetTrigger("surprised");
            difficulty.surprise = false;
        }
    }
}
