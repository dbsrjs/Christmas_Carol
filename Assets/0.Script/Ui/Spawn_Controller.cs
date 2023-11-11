using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Controller : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform wirzard_spawn;

    [SerializeField] private GameObject wirzard;
    [SerializeField] private Blue_Knight knight;
    [SerializeField] private Blue_Tanker tanker;
    [SerializeField] private Blue_Archer archer;

    [SerializeField] private Slider cost_Bar;
    [SerializeField] private Text cost_text;
    [SerializeField] private Text cost_Shadow;

    [SerializeField] private GameManager gameManager;

    public void Wirzard()
    {
        if (gameManager.timeSize == 1 && cost_Bar.value >= 10)
        {
            Instantiate(wirzard, wirzard_spawn);
            cost_Bar.value -= 10;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Knight()
    {
        if (gameManager.timeSize == 1 && cost_Bar.value >= 3)
        {
            Instantiate(knight, parent);
            cost_Bar.value -= 3;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void LvUp_Knight()
    {
        if (gameManager.timeSize == 1 && cost_Bar.value >= 10)
        {
            Blue_Knight knightComponent = knight.GetComponent<Blue_Knight>();
            knightComponent.additionalHP += 20; // additionalHP를 20 증가시킵니다.
            knightComponent.additionalPower += 10; // additionalPower를 10 증가시킵니다.

            cost_Bar.value -= 10;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Tanker()
    {
        if (gameManager.timeSize == 1 && cost_Bar.value >= 5)
        {
            Instantiate(tanker, parent);
            cost_Bar.value -= 5;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Archer()
    {
        if (gameManager.timeSize == 1 && cost_Bar.value >= 7)
        {
            Instantiate(archer, parent);
            cost_Bar.value -= 7;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

}
