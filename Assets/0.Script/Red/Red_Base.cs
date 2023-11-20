using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Base : MonoBehaviour
{
    [HideInInspector] public int HP;
    [SerializeField] private GameObject victory;
    [SerializeField] private Animator animator;
    [SerializeField] private Ui ui;


    private void Start()
    {
        victory.SetActive(false);
        HP = 200;
    }

    public void Hit(int damage)
    {
        HP -= damage;   //�������� ����ؼ� hp ����
        ui.Red_Hit(damage);
        animator.SetTrigger("doHit");   //hit �ִϸ��̼� ����

        if (HP <= 0)
        {            
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            victory.SetActive(true);
        }
    }
}
