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
        HP -= damage;   //데미지에 비례해서 hp 감소
        print(HP);
        ui.Blue_Hit(damage);
        animator.SetTrigger("doHit");   //doHit 애니메이션 실행

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");   //doDie 애니메이션 실행
            defeat.SetActive(true);
        }
    }
}
