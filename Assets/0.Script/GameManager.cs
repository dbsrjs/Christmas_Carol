using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int timeSize = 1;

    [SerializeField] private Red_Base red_Base;
    [SerializeField] private Blue_Base blue_Base;

    void Update()
    {
        Time.timeScale = timeSize;

        if (red_Base.HP <= 0 || blue_Base.HP <= 0)
        {
            timeSize = 0;
        }
    }
}
