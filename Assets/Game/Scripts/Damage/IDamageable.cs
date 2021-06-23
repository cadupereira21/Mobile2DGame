﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
    event Action DeathEvent;
    bool IsDead { get; }
}
