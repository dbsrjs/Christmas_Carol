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
        HP -= damage;   //데미지에 비례해서 hp 감소
        ui.Red_Hit(damage * 2);
        animator.SetTrigger("doHit");   //hit 애니메이션 실행

        if (HP <= 0)
        {            
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");   //doDie 애니메이션 실행
            Debug.Log("test");
            victory.SetActive(true);
        }
    }
}
