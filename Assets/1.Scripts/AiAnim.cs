using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAnim : MonoBehaviour
{
    public difficulty difficulty = null;
    public stress stress = null;
    public Questmanager Questmanager;
    public NavMeshAgent agent;
    public Animator _animator;

    void Start()
    {
        Questmanager = GameObject.Find("Questmanager").GetComponent<Questmanager>();
        _animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = 1.8f;
    }

    void Update()
    {
        _animator.SetFloat("Blend", agent.speed * 0.1f + 0.1f, 0.1f, Time.deltaTime);
    }

    public void quest()
    {
        if(Questmanager.count == 1 || Questmanager.count == 2)
        {
            Questmanager.count++;
        }
        else if(Questmanager.count == 3)
        {
            stress.Stress -= 5.0f;
            Questmanager.countquest();
        }
        difficulty.surprise = false;
    }
}
