using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSkull : EnemyController
{
    void Start()
    {
        this.health = 1;
        this.movespeed = 2.5f;
    }
}
