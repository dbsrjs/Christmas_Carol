using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawn_Controller : MonoBehaviour
{
    [SerializeField] private Transform parent;
    [SerializeField] private Transform wirzard_spawn;

    [SerializeField] private GameObject wirzard;
    [SerializeField] private GameObject tanker;
    [SerializeField] private GameObject knight;
    [SerializeField] private GameObject archer;

    [SerializeField] private Slider cost_Bar;
    [SerializeField] private Text cost_text;
    [SerializeField] private Text cost_Shadow;

    private GameManager gameManager;

    private void Start()
    {
        gameManager = GetComponent<GameManager>();
    }

    public void Wirzard()
    {
        if (cost_Bar.value >= 10)
        {
            Instantiate(wirzard, wirzard_spawn);
            cost_Bar.value -= 10;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Knight()
    {
        if (cost_Bar.value >= 3)
        {
            Instantiate(knight, parent);
            cost_Bar.value -= 3;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Tanker()
    {
        if (cost_Bar.value >= 5)
        {
            Instantiate(tanker, parent);
            cost_Bar.value -= 5;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Archer()
    {
        if (cost_Bar.value >= 7)
        {
            Instantiate(archer, parent);
            cost_Bar.value -= 7;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }
}
