using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Red_Tanker monster;
    [SerializeField] private Animator animator;

    GameObject[] redObjects;

    GameObject closestRedObject = null;
    float minDistance = Mathf.Infinity;

    float atkTime = 1.5f;    //���� �ӵ�
    private float atkTimer;

    public int HP = 100; // public int HP { get; set; }

    IEnumerator Start()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");
        yield return new WaitForSeconds(0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 || redObjects == null)   //�÷��̾ ���ų� �׾��� ��
            return;

        if (redObjects != null)
        {
            foreach (GameObject redObject in redObjects)
            {
                if (redObject != null)
                {
                    float distance = Vector2.Distance(redObject.transform.position, transform.position);
                    // ���� distance ������ ����Ͽ� �ʿ��� �۾��� ������ �� �ֽ��ϴ�.

                    if (distance <= minDistance)  //�Ÿ��� 1 ���϶��
                    {
                        closestRedObject = redObject;
                        minDistance = distance;

                        atkTimer += Time.deltaTime;
                        //����
                        if (atkTimer > atkTime)
                        {
                            atkTimer = 0;
                            monster.Hit(40);
                            animator.SetTrigger("doAttack");    //doAttack �ִϸ��̼� ����
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

    public void Hit(int damage)    //damage = power(Monster) = 10;
    {
        Debug.Log("Blue Attack");
        animator.SetTrigger("doHit");    //doHit �ִϸ��̼� ����
        HP -= damage;   //HP ����

        if (HP <= 0)    //�׾��� ��
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
            animator.SetTrigger("doDie");    //doDie �ִϸ��̼� ����
            //yield return new WaitForSeconds(2f);    //2�� ��
            Destroy(gameObject);    //���� ����
        }
    }
}
