using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Base : MonoBehaviour
{
    [HideInInspector] public int HP = 100;
    [SerializeField] private GameObject victory;
    [SerializeField] private Animator animator;

    [SerializeField] private GameObject red_Health;
    private int health_Hp = 200;
    private void Start()
    {
        victory.SetActive(false);
    }

    public void Hit(int damage)
    {
        //Debug.Log("Red_Base Attack");        
        HP -= damage;   //�������� ����ؼ� hp ����

        animator.SetTrigger("doHit");   //hit �ִϸ��̼� ����

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            victory.SetActive(true);
        }
    }

    public void Health(int damage)
    {
        //Debug.Log("test");
        RectTransform rect_tran = red_Health.GetComponent<RectTransform>();
        health_Hp -= damage;
        rect_tran.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, health_Hp);
    }
}
