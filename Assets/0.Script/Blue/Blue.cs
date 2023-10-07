using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    [SerializeField] private Animator animator;

    GameObject[] redObjects;

    private float stoppingDistance = 0.7f; // ���� �Ÿ� ����

    private float atkTime = 1.5f; // ���� ����
    private float atkTimer;

    [HideInInspector] public int HP = 100; // public int HP { get; set; }

    void Update()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");

        if (HP <= 0 || redObjects == null)
            return;

        float closestDistance = Mathf.Infinity;
        GameObject closestRedObject = null;


        foreach (GameObject redObject in redObjects)
        {
            if (redObject != null)
            {
                float distance = Vector2.Distance(redObject.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestRedObject = redObject;
                }
            }
        }

        if (closestRedObject != null)
        {
            if (closestDistance > stoppingDistance)
            {
                float speed = 1.0f; // �̵� �ӵ� ����
                Vector2 direction = (closestRedObject.transform.position - transform.position).normalized;
                transform.position += (Vector3)direction * speed * Time.deltaTime;

                animator.SetTrigger("doMove"); // �̵� �ִϸ��̼� ���
            }
        }

        foreach (GameObject redObject in redObjects)
        {
            if (redObject != null)
            {
                float distance = Vector2.Distance(redObject.transform.position, transform.position);    //���� ����� ������ ��ü�� ���ϴ� ������ ��Ÿ���� ���� �����Դϴ�.

                //distance <= minDistance && 
                if (distance <= stoppingDistance) // ���� ���¿����� ���� �����ϵ��� ���� �߰�
                {
                    atkTimer += Time.deltaTime;
                    // ����
                    if (atkTimer > atkTime)
                    {
                        atkTimer = 0;
                        redObject.GetComponent<Red_Tanker>().Hit(40);
                        animator.SetTrigger("doAttack"); // doAttack �ִϸ��̼� ����
                    }
                }
            }
        }
    }

    public void Hit(int damage)
    {
        Debug.Log("Blue Attack");
        HP -= damage;   //�������� ����ؼ� hp ����
        animator.SetTrigger("doHit");   //hit �ִϸ��̼� ����

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");   //doDie �ִϸ��̼� ����
            Destroy(gameObject);    //��ü ����
        }
    }
}
