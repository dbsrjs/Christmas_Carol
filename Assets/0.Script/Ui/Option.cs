using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    public void OnClickExitButton() // 버튼 클릭 이벤트에 연결할 함수
    {
        Application.Quit(); // 게임 종료
    }
}