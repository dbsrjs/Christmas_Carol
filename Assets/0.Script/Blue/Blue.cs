using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [HideInInspector] public GameObject[] redObjects;
    [HideInInspector] public GameObject[] redBase;

    protected int HP; //100
    protected int power;    //40
    protected float speed; //1f �̵� �ӵ�
    protected float atkTime;    //1.5f ���� �ӵ�

    private float stoppingDistance = 0.7f; // ���� �Ÿ� ����  (1.4f)
    private float atkTimer;

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

    void MoveAndAttack(GameObject[] targetObjects)  //���� ����� Ÿ�ٿ��� �̵��ϰų� ����
    {
        GameObject closestTarget = GetClosestTarget(targetObjects); // ���� ����� Ÿ�� �˻�

        if (closestTarget != null)
        {
            // ���� ��ġ�� ���� ����� Ÿ�ٰ��� �Ÿ��� ���
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // targetObjects�� redBase�� ��� stoppingDistance�� 1.4�� ����
            float currentStoppingDistance = targetObjects[0].tag == "Red_Base" ? 1.4f : stoppingDistance;

            if (distance > currentStoppingDistance) //Ÿ�ٿ��� �̵�
            {
                animator.SetTrigger("doMove");
                MoveToTarget(closestTarget);
            }

            else   //Ÿ�� ����
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

    void MoveToTarget(GameObject target)    //Ÿ�ٿ��� �̵�
    {
        // Ÿ�ٰ� ���� ��ġ ������ ������ ����մϴ�.
        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;  //Ÿ�ٿ��� �̵�
    }

    void AttackTarget(GameObject target)
    {
        atkTimer = 0;

        if (target.tag == "Red")
        {
            target.GetComponent<Red>().Hit(power);  //40
        }

        else if (target.tag == "Red_Base")
        {
            target.GetComponent<Red_Base>().Hit(power / 4); //10
        }

        animator.SetTrigger("doAttack"); // doAttack �ִϸ��̼� ����
    }

    public void Hit(int damage) //����
    {
        Debug.Log("Blue Attack");
        HP -= damage;   //�������� ����ؼ� hp ����
        animator.SetTrigger("doHit");    //hit �ִϸ��̼� ����

        if (HP <= 0)    //������
        {           
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die()
    {
        Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D ����
        Destroy(GetComponent<BoxCollider2D>()); //BoxCollider2D����
        animator.SetTrigger("doDie");    //doDie �ִϸ��̼� ����
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);    //��ü ����
    }
}
