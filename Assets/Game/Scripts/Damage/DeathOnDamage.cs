﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathOnDamage : MonoBehaviour, IDamageable
{
    public bool IsDead { get; private set; }

    public event Action DeathEvent;

    private void Awake()
    {
        IsDead = false;
    }

    public void TakeDamage(int damage)
    {
        IsDead = true;
        DeathEvent.Invoke(); // Quando algo tomar dano, o evento será invocado
    }
}

