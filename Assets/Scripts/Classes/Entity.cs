using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class Entity
{
    public int HealtPoints { get; set; } = 100;

    public bool IsAlive = true;

    public void UpdateState()
    {
        if (HealtPoints == 0)
            IsAlive = false;
    }
    public void GetDamage(int damage)
    {
        if (HealtPoints >= damage)
            HealtPoints -= damage;
        else
            HealtPoints = 0;
        UpdateState();
    }
}
