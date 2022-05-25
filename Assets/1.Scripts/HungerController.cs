﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerController : MonoBehaviour
{
    public Slider HungerSlider;
    Animator _animator;
    public float Hunger;
    float maxHunger = 100f;
    

    void Start()
    {
        Hunger = maxHunger;
        _animator = this.GetComponent<Animator>();
    }


    void Update()
    {
        HungerSlider.value = Hunger;
        Hunger -= 1f * Time.deltaTime;
        if(Hunger <= 0)
        {
            Hunger = 0;
        }
        hungryaim();
    }

    void hungryaim()
    {
        _animator.SetLayerWeight(3, 1.0f - Hunger/100.0f);
    }

    void eat3()
    {
        Hunger += 20;

        if(Hunger >= 100)
        {
            Hunger = 100;
        }
    }
}
