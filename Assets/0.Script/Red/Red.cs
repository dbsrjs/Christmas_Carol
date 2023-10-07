using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    [SerializeField] private Animator animator;

    GameObject[] blueObjects;

    private float stoppingDistance = 0.7f; // ���� �Ÿ� ����

    private float atkTime = 1.5f; // ���� ����
    private float atkTimer;

    [HideInInspector] public int HP = 100; // public int HP { get; set; }

    void Update()
    {
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");

        if (HP <= 0 || blueObjects == null)
            return;

        float closestDistance = Mathf.Infinity;
        GameObject closestBlueObject = null;


        foreach (GameObject blueObject in blueObjects)
        {
            if (blueObject != null)
            {
                float distance = Vector2.Distance(blueObject.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestBlueObject = blueObject;
                }
            }
        }

        if (closestBlueObject != null)
        {
            if (closestDistance > stoppingDistance)
            {
                float speed = 1.0f; // �̵� �ӵ� ����
                Vector2 direction = (closestBlueObject.transform.position - transform.position).normalized;
                transform.position += (Vector3)direction * speed * Time.deltaTime;

                animator.SetTrigger("doMove"); // �̵� �ִϸ��̼� ���
            }
        }

        foreach (GameObject blueObject in blueObjects)
        {
            if (blueObject != null)
            {
                float distance = Vector2.Distance(blueObject.transform.position, transform.position);    //���� ����� ������ ��ü�� ���ϴ� ������ ��Ÿ���� ���� �����Դϴ�.

                //distance <= minDistance && 
                if (distance <= stoppingDistance) // ���� ���¿����� ���� �����ϵ��� ���� �߰�
                {
                    atkTimer += Time.deltaTime;
                    // ����
                    if (atkTimer > atkTime)
                    {
                        atkTimer = 0;
                        blueObject.GetComponent<Blue_Tanker>().Hit(50);
                        animator.SetTrigger("doAttack"); // doAttack �ִϸ��̼� ����
                    }
                }
            }
        }
    }

    public void Hit(int damage)
    {
        Debug.Log("Red Attack");
        HP -= damage;   //�������� ����ؼ� hp ����
        animator.SetTrigger("doHit");    //hit �ִϸ��̼� ����

        if (HP <= 0)    //������
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");    //doDie �ִϸ��̼� ����            
            Destroy(gameObject);    //��ü ����
        }
    }
}
