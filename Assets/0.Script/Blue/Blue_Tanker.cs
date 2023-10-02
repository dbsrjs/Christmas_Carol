using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Animator animator;

    GameObject[] redObjects;

    GameObject closestRedObject = null;
    float minDistance = Mathf.Infinity;

    float atkTime = 1.5f;    //���� �ӵ�
    private float atkTimer;

    public int HP = 100; // public int HP { get; set; }

    void Start()
    {
            redObjects = GameObject.FindGameObjectsWithTag("Red");
    }
    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 || redObjects == null)   //�÷��̾ ���ų� �׾��� ��
            return;

        foreach (GameObject redObject in redObjects)
        {
            if (redObject != null)
            {                
                // ���� ������Ʈ���� �Ÿ��� ����մϴ�.
                float distance = Vector2.Distance(redObject.transform.position, transform.position);

                // �� �Ÿ��� ���ݱ��� ã�� �ּ� �Ÿ����� ������, �� ������Ʈ�� �� �Ÿ��� �����մϴ�.
                if (distance <= minDistance)
                {
                    closestRedObject = redObject;
                    minDistance = distance;

                    atkTimer += Time.deltaTime;
                    //����
                    if (atkTimer > atkTime)
                    {
                        atkTimer = 0;
                        redObject.GetComponent<Red_Tanker>().Hit(40);
                        animator.SetTrigger("doAttack");    //doAttack �ִϸ��̼� ����
                    }
                }
            }

            else
            {
                redObjects = null;
                if (redObjects == null)
                {

                }
                Debug.Log("null");
                redObjects = GameObject.FindGameObjectsWithTag("Red");
            }
        }

        // ���� ����� "Red" �±׸� ���� ������Ʈ�� �̵��ϴ� �ڵ带 �ۼ��մϴ�.
        if (closestRedObject != null)
        {
            float speed = 1.0f; // ���ϴ� �ӵ��� �����մϴ�.
            Vector2 direction = (closestRedObject.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
            animator.SetTrigger("doMove");    //doMove �ִϸ��̼� ����
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
