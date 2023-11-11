using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject exit;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        gameObject.SetActive(false);
        exit.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
        //gameManager.GameStop();
    }

    public void Close()
    {
        gameObject.SetActive(false);
        gameManager.GameStart();
    }

    public void OnExit()
    {
        exit.SetActive(true);
    }

    public void OnExitButton()
    {
        UnityEditor.EditorApplication.isPlaying = false;    //게임 종료(실행)
        Application.Quit(); // 게임 종료(build)
        Debug.Log("게임을 종료합니다");
    }

    public void OnNoExitButton()
    {
        exit.SetActive(false);
    }
}