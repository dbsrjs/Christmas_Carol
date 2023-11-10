using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int timeSize = 1;

    [SerializeField] private Red_Base red_Base;
    [SerializeField] private Blue_Base blue_Base;
    [SerializeField] private Ui ui;

    void Update()
    {
        Time.timeScale = timeSize;

        if (red_Base.HP <= 0 || blue_Base.HP <= 0)
        {
            GameStop();
        }
    }

    public void GameStart()
    {
        timeSize = 1;
    }

    public void GameStop()
    {
        timeSize = 0;
    }
}
