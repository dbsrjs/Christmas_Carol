using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Archer : Red
{
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject prefab;
    public void Attack()
    {
        Instantiate(prefab, parent);
    }
}
