using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Knight : Blue
{
    [HideInInspector] public int additionalHP;
    [HideInInspector] public int additionalPower;

    private void Start()
    {
        HP = 100 + additionalHP;
        power = 40 + additionalPower;
        Debug.Log(HP);
        speed = 1f;
        atkTime = 1.4f;
    }
}
