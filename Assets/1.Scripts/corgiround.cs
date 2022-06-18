using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class corgiround : MonoBehaviour
{
    public difficulty difficulty = null;
    public List<GameObject> peopleList = new List<GameObject>();
    public List<NavMeshAgent> agent = new List<NavMeshAgent>();
    public List<Animator> _animator = new List<Animator>();

    void Start()
    {
    }

    void Update()
    {
        if(difficulty.surprise == true)
        {
            for(int i = 0; i < peopleList.Count; i++)
            {
                difficulty.surprise = false;
                agent[i].speed = 0.0f;
                _animator[i].SetTrigger("surprised");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "man")
        {
            peopleList.Add(other.gameObject);
            for(int i = 0; i < peopleList.Count; i++)
            {
                agent.Remove(peopleList[i].GetComponent<NavMeshAgent>());
                _animator.Remove(peopleList[i].GetComponent<Animator>());
                agent.Add(peopleList[i].GetComponent<NavMeshAgent>());
                _animator.Add(peopleList[i].GetComponent<Animator>());
            }
        }   
    }

    void OnTriggerExit(Collider other)
    {
        if(other.tag == "man")
        {
            
            for(int i = 0; i < peopleList.Count; i++)
            {
                agent.Remove(peopleList[i].GetComponent<NavMeshAgent>());
                _animator.Remove(peopleList[i].GetComponent<Animator>());
            }
            peopleList.Remove(other.gameObject);
            for(int i = 0; i < peopleList.Count; i++)
            {
                agent.Add(peopleList[i].GetComponent<NavMeshAgent>());
                _animator.Add(peopleList[i].GetComponent<Animator>());
            }
        }
    }
}
