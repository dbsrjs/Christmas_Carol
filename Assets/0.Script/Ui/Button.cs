using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private string type;

    [SerializeField]  private Camera main;

    public void OnPointerEnter(PointerEventData eventData)  //마우스 충돌 시작
    {
        switch (type)
        {
            case "right":
                main.right = true;
                break;

            case "left":
                main.left = true;
                break;
        }
    }

    public void OnPointerExit(PointerEventData eventData)   //마우스 충돌 종료
    {
        switch (type)
        {
            case "right":
                main.right = false;
                break;

            case "left":
                main.left = false;
                break;
        }
    }
}
