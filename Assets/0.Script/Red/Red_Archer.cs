using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Archer : Red
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;

    void Start()
    {
        HP = 60;
        speed = 1f;
        atkTime = 1.6f;
    }

    public void Attack()
    {
        Instantiate(prefab, parent);
    }
}
