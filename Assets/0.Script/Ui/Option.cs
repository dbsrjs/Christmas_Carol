using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject Enter;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        gameManager.GameStop();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        gameManager.GameStart();
    }

    public void OnClickExitButton()
    {
        Application.Quit(); // 게임 종료
        Debug.Log("게임을 종료합니다");
    }
}