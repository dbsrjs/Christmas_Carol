using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [HideInInspector] public GameObject[] redObjects;
    [HideInInspector] public GameObject[] redBase;

    private float stoppingDistance = 0.7f; // 멈출 거리 설정  (1.4f)

    private float atkTime = 1.5f; // 공격 간격
    private float atkTimer;

    [HideInInspector] public int HP = 100; // public int HP { get; set; }

    void Update()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");
        redBase = GameObject.FindGameObjectsWithTag("Red_Base");

        if (HP <= 0)
            return;

        //redObjects의 객체수가 0 초과일 경우 targetObjects를 redObjects로 설정
        GameObject[] targetObjects = redObjects.Length > 0 ? redObjects : redBase;
        MoveAndAttack(targetObjects);
    }

    void MoveAndAttack(GameObject[] targetObjects)
    {
        GameObject closestTarget = GetClosestTarget(targetObjects);

        if (closestTarget != null)
        {
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // targetObjects가 redBase일 경우 stoppingDistance를 1.4로 설정
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
        float speed = 1.0f; // 이동 속도 설정
        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;

        animator.SetTrigger("doMove"); // 이동 애니메이션 재생
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

        animator.SetTrigger("doAttack"); // doAttack 애니메이션 실행
    }

    public void Hit(int damage)
    {
        Debug.Log("Blue Attack");
        HP -= damage;   //데미지에 비례해서 hp 감소
        animator.SetTrigger("doHit");    //hit 애니메이션 실행

        if (HP <= 0)    //죽으면
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");    //doDie 애니메이션 실행            
            Destroy(gameObject);    //객체 삭제
        }
    }
}
