using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Base : MonoBehaviour
{
    [HideInInspector] public int HP = 100;
    [SerializeField] private GameObject defeat;
    [SerializeField] private Animator animator;

    private void Start()
    {
        defeat.SetActive(false);
    }

    public void Hit(int damage)
    {
        Debug.Log("Red_Base Attack");
        HP -= damage;   //�������� ����ؼ� hp ����
        animator.SetTrigger("doHit");   //hit �ִϸ��̼� ����

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            defeat.SetActive(true);
        }
    }
}
