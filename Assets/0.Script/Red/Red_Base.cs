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
        HP -= damage;   //�������� ����ؼ� hp ����
        //animator.SetTrigger("doHit");   //hit �ִϸ��̼� ����

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            //animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            Destroy(gameObject);    //��ü ����
        }
    }
}
