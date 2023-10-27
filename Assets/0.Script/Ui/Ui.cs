using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ui : MonoBehaviour
{
    [SerializeField] private GameObject red_Health;
    [SerializeField] private GameObject blue_Health;

    [SerializeField] private Text red_Text;
    [SerializeField] private Text blue_Text;

    private int red_health = 200;
    private int blue_health = 200;

    public void Red_Hit(int damage)
    {
        RectTransform rect_tran = red_Health.GetComponent<RectTransform>();
        red_health -= damage;
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, red_health);
    }

    public void Blue_Hit(int damage)
    {
        RectTransform rect_tran = blue_Health.GetComponent<RectTransform>();
        blue_health -= damage;
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blue_health);
    }

    public void Blue_Hill(int hill)
    {
        RectTransform rect_tran = blue_Health.GetComponent<RectTransform>();
        blue_health += hill;
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, blue_health);
    }
}
