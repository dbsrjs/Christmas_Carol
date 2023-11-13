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

    public void Open()  //�ɼ� â ����
    {
        if (exit.activeSelf == false)
        {
            option.SetActive(true);
            gameManager.GameStop();
        }
        
    }

    public void Close() //�ɼ� â �ݱ�
    {
        option.SetActive(false);
        gameManager.GameStart();
    }

    public void OnExit()    //���� ���� ��ư ����
    {
        option.SetActive(false);
        exit.SetActive(true);
    }
    public void OnNoExitButton()    //���� ���� ��ư �ݱ�
    {
        option.SetActive(true);
        exit.SetActive(false);
    }

    public void OnExitButton()  //���� ����
    {
        UnityEditor.EditorApplication.isPlaying = false;    //���� ����(����)
        Application.Quit(); // ���� ����(build)
    }

}