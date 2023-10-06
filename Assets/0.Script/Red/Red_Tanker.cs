using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Tanker : MonoBehaviour
{
    [SerializeField] private Blue_Tanker p;
    [SerializeField] private Animator animator;

    GameObject[] blueObjects;

    GameObject closestRedObject = null;
    float minDistance = Mathf.Infinity;

    float atkTime = 1.6f;    //���� �ӵ�

    [HideInInspector] public int hp = 100;   //ä��

    private float atkTimer;

    // Update is called once per frame

    IEnumerator Start()
    {
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");
        yield return new WaitForSeconds(0.5f);
    }
    void Update()
    {
        if (p == null || hp <= 0 || blueObjects == null)   //�÷��̾ ���ų� �׾��� ��
            return;

        if (blueObjects != null)
        {
            foreach (GameObject blueObject in blueObjects)
            {
                if (blueObject != null)
                {
                    float distance = Vector2.Distance(blueObject.transform.position, transform.position);
                    // ���� distance ������ ����Ͽ� �ʿ��� �۾��� ������ �� �ֽ��ϴ�.

                    if (distance <= minDistance)  //�Ÿ��� 1 ���϶��
                    {
                        closestRedObject = blueObject;
                        minDistance = distance;

                        atkTimer += Time.deltaTime;
                        //����
                        if (atkTimer > atkTime)
                        {
                            atkTimer = 0;
                            blueObject.GetComponent<Blue_Tanker>().Hit(10);
                        }
                    }

                    else
                    {
                        if (closestRedObject != null)
                        {
                            animator.SetTrigger("doMove");    //doMove �ִϸ��̼� ����
                            float speed = 0.3f;
                            Vector2 direction = (closestRedObject.transform.position - transform.position).normalized;
                            transform.position += (Vector3)direction * speed * Time.deltaTime;
                        }
                    }
                }
            }
        }
    }

    public void Hit(int damage)
    {
        Debug.Log("Red Attack");
        hp -= damage;   //�������� ����ؼ� hp ����
        animator.SetTrigger("doHit");    //hit �ִϸ��̼� ����

        if (hp <= 0)    //������
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");    //doDie �ִϸ��̼� ����            
            Destroy(gameObject);    //��ü ����
        }
    }
}
