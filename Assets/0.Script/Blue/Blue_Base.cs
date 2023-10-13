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
        HP -= damage;   //데미지에 비례해서 hp 감소
        animator.SetTrigger("doHit");   //hit 애니메이션 실행

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");   //doDie 애니메이션 실행
            defeat.SetActive(true);
        }
    }
}
