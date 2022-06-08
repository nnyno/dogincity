﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAnim : MonoBehaviour
{
    public difficulty difficulty = null;
    public Questmanager Questmanager;
    public NavMeshAgent agent;
    Animator _animator;

    void Start()
    {
        Questmanager = GameObject.Find("Questmanager").GetComponent<Questmanager>();
        _animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1.8f;
    }

    void Update()
    {
        if(difficulty.surprise == true)
        {
            _animator.SetTrigger("surprised");
            agent.speed = 0f;
            difficulty.surprise = false;
        }
        _animator.SetFloat("Blend", agent.speed * 0.1f + 0.1f, 0.1f, Time.deltaTime);
    }

    public void humango()
    {
        if(Questmanager.count == 1 || Questmanager.count == 2)
        {
            Questmanager.count++;
        }
        else if(Questmanager.count == 3)
        {
            Questmanager.countquest();
        }
        agent.speed = 1.8f;
    }
}
