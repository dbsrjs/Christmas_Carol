using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [HideInInspector] public GameObject[] blueObjects;
    [HideInInspector] public GameObject[] blueBase;

    protected int HP; //100
    protected int power;    //20
    protected float speed; //1f �̵� �ӵ�
    protected float atkTime;    //1.5f ���� �ӵ�

    private float stoppingDistance = 0.7f; // ���� �Ÿ� ����  (1.4f)
    private float atkTimer;


    void Update()
    {
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");
        blueBase = GameObject.FindGameObjectsWithTag("Blue_Base");

        if (HP <= 0)
            return;

        //redObjects�� ��ü���� 0 �ʰ��� ��� targetObjects�� redObjects�� ����
        GameObject[] targetObjects = blueObjects.Length > 0 ? blueObjects : blueBase;
        MoveAndAttack(targetObjects);
    }

    void MoveAndAttack(GameObject[] targetObjects)
    {        
        GameObject closestTarget = GetClosestTarget(targetObjects);

        if (closestTarget != null)
        {
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // targetObjects�� redBase�� ��� stoppingDistance�� 1.4�� ����
            float currentStoppingDistance = targetObjects[0].tag == "Blue_Base" ? 1.4f : stoppingDistance;

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
        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        animator.SetTrigger("doMove"); // �̵� �ִϸ��̼� ���
    }

    void AttackTarget(GameObject target)
    {
        atkTimer = 0;

        if (target.tag == "Blue")
        {
            target.GetComponent<Blue>().Hit(power);
        }

        else if (target.tag == "Blue_Base")
        {
            target.GetComponent<Blue_Base>().Hit(40);    //5
        }

        animator.SetTrigger("doAttack"); // doAttack �ִϸ��̼� ����
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
