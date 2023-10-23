using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Archer : Red
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;

    void Start()
    {
        HP = 100;
        power = 20;
        speed = 1f;
        atkTime = 1.2f;
    }

    public void Attack()
    {
        Instantiate(prefab, parent);
    }
}
