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
    protected float speed; //1f 이동 속도
    protected float atkTime;    //1.5f 공격 속도

    private float stoppingDistance = 0.7f; // 멈출 거리 설정  (1.4f)
    private float atkTimer;

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

    void MoveAndAttack(GameObject[] targetObjects)  //가장 가까운 타겟에게 이동하거나 공격
    {
        GameObject closestTarget = GetClosestTarget(targetObjects); // 가장 가까운 타겟 검색

        if (closestTarget != null)
        {
            // 현재 위치와 가장 가까운 타겟과의 거리를 계산
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // targetObjects가 redBase일 경우 stoppingDistance를 1.4로 설정
            float currentStoppingDistance = targetObjects[0].tag == "Red_Base" ? 1.4f : stoppingDistance;

            if (distance > currentStoppingDistance) //타겟에게 이동
            {
                animator.SetTrigger("doMove");
                MoveToTarget(closestTarget);
            }

            else   //타겟 공격
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

    GameObject GetClosestTarget(GameObject[] targets)   //가장 가까운 타겟 검색
    {
        float closestDistance = Mathf.Infinity; // 가장 가까운 거리를 무한대로 초기화
        GameObject closestTarget = null;    // 가장 가까운 타겟을 null로 초기화

        foreach (GameObject target in targets)
        {
            if (target != null)
            {
                // 현재 위치와 타겟과의 거리를 계산
                float distance = Vector2.Distance(target.transform.position, transform.position);

                if (distance < closestDistance) // 계산된 거리가 현재 가장 가까운 거리보다 작다면
                {                    
                    closestDistance = distance; // 가장 가까운 거리를 새로운 거리로 업데이트하고
                    closestTarget = target; // 가장 가까운 타겟을 새로운 타겟으로 업데이트
                }
            }
        }

        return closestTarget;
    }

    void MoveToTarget(GameObject target)    //타겟에게 이동
    {
        // 타겟과 현재 위치 사이의 방향을 계산합니다.
        Vector2 direction = (target.transform.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;  //타겟에게 이동
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

        animator.SetTrigger("doAttack"); // doAttack 애니메이션 실행
    }

    public void Hit(int damage) //공격
    {
        Debug.Log("Blue Attack");
        HP -= damage;   //데미지에 비례해서 hp 감소
        animator.SetTrigger("doHit");    //hit 애니메이션 실행

        if (HP <= 0)    //죽으면
        {           
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die()
    {
        Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
        Destroy(GetComponent<BoxCollider2D>()); //BoxCollider2D삭제
        animator.SetTrigger("doDie");    //doDie 애니메이션 실행
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);    //객체 삭제
    }
}
