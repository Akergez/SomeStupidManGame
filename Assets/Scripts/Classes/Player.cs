using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    public int Hunger { get; set; }

    public Player()
    {
        HealtPoints = 100;
        Hunger = 100;
    }

    public void RecalculateHunger()
    {
        if (Hunger > 0)
            Hunger -= 1;
        else
        if (HealtPoints >= 0)
                HealtPoints -= 1;
        if (Hunger <= HealtPoints) return;
        HealtPoints++;
        Hunger -= 1;
    }

    public void BeAttacked(int damage)
    {
        HealtPoints -= damage;
    }
}