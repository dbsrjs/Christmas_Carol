using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Archer : Blue
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;

    void Start()
    {
        HP = 80;
        speed = 1f;
        atkTime = 1.2f;
    }

    public void Attack()
    {
        Instantiate(prefab, parent);
    }
}
