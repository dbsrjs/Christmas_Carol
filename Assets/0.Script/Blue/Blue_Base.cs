using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Base : MonoBehaviour
{
    [HideInInspector] public int HP;
    [SerializeField] private GameObject defeat;
    [SerializeField] private Animator animator;
    [SerializeField] private Ui ui;

    private void Start()
    {
        defeat.SetActive(false);
        HP = 200;
    }

    public void Hit(int damage)
    {
        HP -= damage;   //�������� ����ؼ� hp ����
        print(HP);
        ui.Blue_Hit(damage);
        animator.SetTrigger("doHit");   //doHit �ִϸ��̼� ����

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            defeat.SetActive(true);
        }
    }
}
