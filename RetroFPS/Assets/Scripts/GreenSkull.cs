/*
     * (Santiago Garcia II)
     * (GreenSkull.cs)
     * (Assignment 5)
     * (The concrete porducts )
*/
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
