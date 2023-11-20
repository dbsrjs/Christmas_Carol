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
    protected float speed; //1f 이동 속도
    protected float atkTime;    //1.5f 공격 속도

    private float stoppingDistance = 0.7f; // 멈출 거리 설정
    private float atkTimer;

    void Update()
    {
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");
        blueBase = GameObject.FindGameObjectsWithTag("Blue_Base");

        if (HP <= 0)
            return;

        //blueObjects의 객체수가 0 초과일 경우 blueObjects를 blueObjects로 설정
        GameObject[] targetObjects = blueObjects.Length > 0 ? blueObjects : blueBase;
        MoveAndAttack(targetObjects);
    }

    void MoveAndAttack(GameObject[] targetObjects)  //가장 가까운 타겟에게 이동하거나 공격
    {
        GameObject closestTarget = GetClosestTarget(targetObjects); //가장 가까운 타겟 검색

        if (closestTarget != null)
        {
            // 현재 위치와 가장 가까운 타겟과의 거리를 계산
            float distance = Vector2.Distance(closestTarget.transform.position, transform.position);

            // Archer 스크렙트를 갖고 있다면 stoppingDistance를 2.3으로 설정 아닐경우 targetObjects가 red_Base일 경우 stoppingDistance를 1.4로 설정 아니라면 기존대로 0.로 설정
            float currentStoppingDistance = GetComponent<Red_Archer>() != null ? 2.7f : targetObjects[0].tag == "Blue_Base" ? 1.4f : stoppingDistance;

            if (distance > currentStoppingDistance) //타겟에게 이동
            {
                animator.SetTrigger("doMove");
                MoveToTarget();
            }

            else   //타겟 공격
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

    void MoveToTarget()    //타겟에게 이동
    {
        Vector3 vec = Vector3.left * 1 * Time.deltaTime;
        transform.position += vec;
    }

    void AttackTarget(GameObject target)    //공격
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

        animator.SetTrigger("doAttack"); // doAttack 애니메이션 실행
    }

    public void Hit(int damage)
    {        
        HP -= damage;   //데미지에 비례해서 hp 감소
        animator.SetTrigger("doHit");    //hit 애니메이션 실행

        if (HP <= 0)    //죽으면
        {
            StartCoroutine("Die");
        }
    }

    private IEnumerator Die()
    {
        this.gameObject.tag = "Die";
        Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
        Destroy(GetComponent<BoxCollider2D>()); //BoxCollider2D삭제
        animator.SetTrigger("doDie");    //doDie 애니메이션 실행
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);    //객체 삭제
    }
}
