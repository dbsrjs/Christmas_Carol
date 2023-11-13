using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    [SerializeField] private GameObject exit;
    [SerializeField] private GameObject option;
    [SerializeField] private GameManager gameManager;

    void Start()
    {
        option.SetActive(false);
        exit.SetActive(false);
    }

    public void Open()  //옵션 창 열기
    {
        if (exit.activeSelf == false)
        {
            option.SetActive(true);
            gameManager.GameStop();
        }
        
    }

    public void Close() //옵션 창 닫기
    {
        option.SetActive(false);
        gameManager.GameStart();
    }

    public void OnExit()    //게임 종료 버튼 열기
    {
        option.SetActive(false);
        exit.SetActive(true);
    }
    public void OnNoExitButton()    //게임 종료 버튼 닫기
    {
        option.SetActive(true);
        exit.SetActive(false);
    }

    public void OnExitButton()  //게임 종료
    {
        UnityEditor.EditorApplication.isPlaying = false;    //게임 종료(실행)
        Application.Quit(); // 게임 종료(build)
    }

}