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
    private int red_num = 20;

    [SerializeField] private Text blue_Text;
    [SerializeField] private Text blue_Shadow;
    private int blue_num = 20;

    private int red_health = 200;
    private int blue_health = 200;

    [SerializeField] private Slider cost_Bar;
    [SerializeField] private Text cost_text;
    [SerializeField] private Text cost_Shadow;

    private int cost_value;

    private float timer;
    void Start()
    {
        cost_Bar.value = 0;

        red_Text.text = red_num.ToString();
        red_Shadow.text = red_num.ToString();

        blue_Text.text = blue_num.ToString();
        blue_Shadow.text = blue_num.ToString();

        cost_text.text = cost_Bar.value.ToString();
        cost_Shadow.text = cost_Bar.value.ToString();
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > 1f)
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
        red_health -= damage;
        red_num -= 1;
        red_Text.text = red_num.ToString();
        red_Shadow.text = red_num.ToString();
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, red_health);
    }

    public void Blue_Hit(int damage)
    {
        RectTransform rect_tran = blue_Health.GetComponent<RectTransform>();
        blue_health -= damage;
        blue_num -= 1;
        blue_Text.text = blue_num.ToString();
        blue_Shadow.text = blue_num.ToString();
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blue_health);
    }
}
