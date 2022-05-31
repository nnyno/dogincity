using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Surprise : MonoBehaviour
{
    public difficulty difficulty = null;
    public NavMeshAgent agent;
    Animator _animator;

    void Start()
    {
        _animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(difficulty.surprise == true)
        {
            _animator.SetTrigger("surprised");
            agent.speed = 0f;
            difficulty.surprise = false;
        }
    }

    public void humango()
    {
        agent.speed = 3.5f;
    }
}
