using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ui : MonoBehaviour
{
    [SerializeField] private GameObject red_Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    public void Hit(int damage)
    {
        RectTransform rect_tran = red_Health.GetComponent<RectTransform>();
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200 - damage);
    }
}
