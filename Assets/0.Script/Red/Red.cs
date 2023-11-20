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

    private float stoppingDistance = 0.7f; // ���� �Ÿ� ����
    private float atkTimer;

    void Update()
    {
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");
        blueBase = GameObject.FindGameObjectsWithTag("Blue_Base");

        if (HP <= 0)
            return;

        //blueObjects�� ��ü���� 0 �ʰ��� ��� blueObjects�� blueObjects�� ����
        GameObject[] targetObjects = blueObjects.Length > 0 ? blueObjects : blueBase;
        MoveAndAttack(targetObjects);
    }

    void MoveAndAttack(GameObject[] targetObjects)  //���� ����� Ÿ�ٿ��� �̵��ϰų� ����
    {
        GameObject closestTarget = GetClosestTarget(targetObjects); //���� ����� Ÿ�� �˻�

        if (closestTarget != null)
        {
            // ���� ��ġ�� ���� ����� Ÿ�ٰ��� �Ÿ��� ���
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // Archer ��ũ��Ʈ�� ���� �ִٸ� stoppingDistance�� 2.3���� ���� �ƴҰ�� targetObjects�� red_Base�� ��� stoppingDistance�� 1.4�� ���� �ƴ϶�� ������� 0.�� ����
            float currentStoppingDistance = GetComponent<Red_Archer>() != null ? 2.7f : targetObjects[0].tag == "Blue_Base" ? 1.4f : stoppingDistance;

            if (distance > currentStoppingDistance) //Ÿ�ٿ��� �̵�
            {
                animator.SetTrigger("doMove");
                MoveToTarget();
            }

            else   //Ÿ�� ����
            {
                atkTimer += Time.deltaTime;
                if (atkTimer > atkTime)
                {
                    AttackTarget(closestTarget);
                    atkTimer = 0;
                }
            }
        }
    }

    GameObject GetClosestTarget(GameObject[] targets)   //���� ����� Ÿ�� �˻�
    {
        float closestDistance = Mathf.Infinity; // ���� ����� �Ÿ��� ���Ѵ�� �ʱ�ȭ
        GameObject closestTarget = null;    // ���� ����� Ÿ���� null�� �ʱ�ȭ

        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                // ���� ��ġ�� Ÿ�ٰ��� �Ÿ��� ���
                float distance = Vector2.Distance(target.transform.position, transform.position);

                if (distance < closestDistance) // ���� �Ÿ��� ���� ���� ����� �Ÿ����� �۴ٸ�
                {
                    closestDistance = distance; // ���� ����� �Ÿ��� ���ο� �Ÿ��� ������Ʈ�ϰ�
                    closestTarget = target; // ���� ����� Ÿ���� ���ο� Ÿ������ ������Ʈ
                }
            }
        }

        return closestTarget;
    }

    void MoveToTarget()    //Ÿ�ٿ��� �̵�
    {
        Vector3 vec = Vector3.left * 1 * Time.deltaTime;
        transform.position += vec;
    }

    void AttackTarget(GameObject target)    //����
    {
        atkTimer = 0;

        if (GetComponent<Red_Archer>() != null)
        {
            transform.GetComponent<Red_Archer>().Attack();
        }

        else if (target.tag == "Blue")
        {
            target.GetComponent<Blue>().Hit(power);
        }

        else if (target.tag == "Blue_Base")
        {
            target.GetComponent<Blue_Base>().Hit(power / 4);    //10
        }

        animator.SetTrigger("doAttack"); // doAttack �ִϸ��̼� ����
    }

    public void Hit(int damage)
    {        
        HP -= damage;   //�������� ����ؼ� hp ����
        animator.SetTrigger("doHit");    //hit �ִϸ��̼� ����

        if (HP <= 0)    //������
        {
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die()
    {
        this.gameObject.tag = "Die";
        Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
        Destroy(GetComponent<BoxCollider2D>()); //BoxCollider2D����
        animator.SetTrigger("doDie");    //doDie �ִϸ��̼� ����
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);    //��ü ����
    }
}
