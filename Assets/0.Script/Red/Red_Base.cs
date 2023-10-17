using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Base : MonoBehaviour
{
    [HideInInspector] public int HP = 100;
    [SerializeField] private GameObject victory;
    [SerializeField] private Animator animator;
    [SerializeField] private Ui ui;


    private void Start()
    {
        victory.SetActive(false);
    }

    public void Hit(int damage)
    {
        //Debug.Log("Red_Base Attack");        
        HP -= damage;   //�������� ����ؼ� hp ����
        ui.Red_Hit(damage * 2);
        animator.SetTrigger("doHit");   //hit �ִϸ��̼� ����

        if (HP <= 0)
        {            
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            Debug.Log("test");
            victory.SetActive(true);
        }
    }
}
