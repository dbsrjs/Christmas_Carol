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
        UnityEditor.EditorApplication.isPlaying = false;    //���� ����(����)
        Application.Quit(); // ���� ����(build)
        Debug.Log("������ �����մϴ�");
    }

    public void OnNoExitButton()
    {
        exit.SetActive(false);
    }
}