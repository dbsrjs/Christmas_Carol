using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Base : MonoBehaviour
{
    [HideInInspector] public int HP = 100;

    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(int damage)
    {
        Debug.Log("Red_Base Attack");
        HP -= damage;   //데미지에 비례해서 hp 감소
        //animator.SetTrigger("doHit");   //hit 애니메이션 실행

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            //animator.SetTrigger("doDie");   //doDie 애니메이션 실행
            Destroy(gameObject);    //객체 삭제
        }
    }
}
