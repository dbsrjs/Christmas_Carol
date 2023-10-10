using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [HideInInspector] public GameObject[] redObjects;
    [HideInInspector] public GameObject[] redBase;

    private float stoppingDistance = 0.7f; // ���� �Ÿ� ����  (1.4f)

    private float atkTime = 1.5f; // ���� ����
    private float atkTimer;

    [HideInInspector] public int HP = 100; // public int HP { get; set; }

    void Update()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");
        redBase = GameObject.FindGameObjectsWithTag("Red_Base");

        if (HP <= 0)
            return;

        //redObjects�� ��ü���� 0 �ʰ��� ��� targetObjects�� redObjects�� ����
        GameObject[] targetObjects = redObjects.Length > 0 ? redObjects : redBase;
        MoveAndAttack(targetObjects);
    }

    void MoveAndAttack(GameObject[] targetObjects)
    {
        GameObject closestTarget = GetClosestTarget(targetObjects);

        if (closestTarget != null)
        {
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // targetObjects�� redBase�� ��� stoppingDistance�� 1.4�� ����
            float currentStoppingDistance = targetObjects[0].tag == "Red_Base" ? 1.4f : stoppingDistance;

            if (distance > currentStoppingDistance)
            {
                MoveToTarget(closestTarget);
            }

            else
            {
                atkTimer += Time.deltaTime;
                if (atkTimer > atkTime)
                {
                    atkTimer = 0;
                    AttackTarget(closestTarget);
                }
            }
        }
    }

    GameObject GetClosestTarget(GameObject[] targets)
    {
        float closestDistance = Mathf.Infinity;
        GameObject closestTarget = null;

        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                float distance = Vector2.Distance(target.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestTarget = target;
                }
            }
        }

        return closestTarget;
    }

    void MoveToTarget(GameObject target)
    {
        float speed = 1.0f; // �̵� �ӵ� ����
        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        animator.SetTrigger("doMove"); // �̵� �ִϸ��̼� ���
    }

    void AttackTarget(GameObject target)
    {        
        atkTimer = 0;

        if (target.tag == "Red")
        {
            target.GetComponent<Red_Tanker>().Hit(40);
        }

        else if (target.tag == "Red_Base")
        {
            target.GetComponent<Red_Base>().Hit(40);    //5
        }

        animator.SetTrigger("doAttack"); // doAttack �ִϸ��̼� ����
    }

    public void Hit(int damage)
    {
        Debug.Log("Blue Attack");
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
