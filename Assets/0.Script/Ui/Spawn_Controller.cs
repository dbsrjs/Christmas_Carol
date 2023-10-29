using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Controller : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform wirzard_spawn;

    [SerializeField] private GameObject wirzard;
    [SerializeField] private GameObject tanker;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject archer;

    [SerializeField] private Blue_Base blue_Base;
    public void Wirzard()
    {
        Instantiate(wirzard, wirzard_spawn);
    }

    public void Tanker()
    {
        Instantiate(tanker, parent);
    }

    public void Knight()
    {
        Instantiate(knight, parent);
    }
    public void Archer()
    {
        Instantiate(archer, parent);
    }
}
