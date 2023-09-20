using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 15f;  //�¿� �̵�
        float clampX = Mathf.Clamp(transform.localPosition.x + x, -2f, 2f);   //�̵��� �� �ִ� ���� ����

        transform.position = new Vector3(clampX, 0f, -10f);
    }

    public void Left_Button()
    {
        
    }

    public void Right_Button()
    {
        Debug.Log("test");
    }
}
