/*
     * (Santiago Garcia II)
     * (BlueSkull.cs)
     * (Assignment 5)
     * (The concrete porducts )
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueSkull : EnemyController
{
   void Start()
    {
        this.health = 3;
        this.movespeed = 2.0f;
    }
}
