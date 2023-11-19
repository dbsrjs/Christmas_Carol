using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{    
    [SerializeField] private GameObject red_Health;
    [SerializeField] private GameObject blue_Health;

    [SerializeField] private Text red_Text;
    [SerializeField] private Text red_Shadow;

    [SerializeField] private Text blue_Text;
    [SerializeField] private Text blue_Shadow;

    [SerializeField] private Slider cost_Bar;
    [SerializeField] private Text cost_text;
    [SerializeField] private Text cost_Shadow;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Red_Base red_Base;
    [SerializeField] private Blue_Base blue_Base;
    private float timer;

    void Start()
    {
        cost_Bar.value = 0;

        red_Text.text = (red_Base.HP / 10).ToString();
        red_Shadow.text = (red_Base.HP / 10).ToString();

        blue_Text.text = (blue_Base.HP / 10).ToString();
        blue_Shadow.text = (blue_Base.HP / 10).ToString();

        cost_text.text = cost_Bar.value.ToString();
        cost_Shadow.text = cost_Bar.value.ToString();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.65f)
        {
            cost_Bar.value += 1;
            timer = 0;
            cost_text.text = cost_Bar.value.ToString();
            cost_Shadow.text = cost_Bar.value.ToString();
        }
    }

    public void Red_Hit(int damage)
    {
        RectTransform rect_tran = red_Health.GetComponent<RectTransform>();
        red_Text.text = (red_Base.HP / 10).ToString();
        red_Shadow.text = (red_Base.HP / 10).ToString();
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, red_Base.HP);
    }

    public void Blue_Hit(int damage)
    {
        RectTransform rect_tran = blue_Health.GetComponent<RectTransform>();
        blue_Text.text = (blue_Base.HP / 10).ToString();
        blue_Shadow.text = (blue_Base.HP / 10).ToString();
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blue_Base.HP);
    }
}
