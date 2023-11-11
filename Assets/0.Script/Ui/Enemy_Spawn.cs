using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawn : MonoBehaviour
{
    [SerializeField] private Transform parent;

    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject tanker;
    [SerializeField] private GameObject archer;

    private float timer_knight;
    private float timer_tanker;
    private float timer_archer;

    private void Update()
    {
        
        //timer_knight += Time.deltaTime;
        timer_tanker += Time.deltaTime;
        //timer_archer += Time.deltaTime;

        if (timer_knight >= 3.7f)
        {
            Instantiate(knight, parent);
            timer_knight = 0f;
        }

        if (timer_tanker >= 5.7f)
        {
            Instantiate(tanker, parent);
            timer_tanker = 0;
        }

        if (timer_archer >= 6.7f)
        {
            Instantiate(archer, parent);
            timer_archer = 0;
        }
        
    }
}
