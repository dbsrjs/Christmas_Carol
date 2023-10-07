using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
    [SerializeField] private Animator animator;

    GameObject[] redObjects;

    private float stoppingDistance = 0.7f; // 멈출 거리 설정

    private float atkTime = 1.5f; // 공격 간격
    private float atkTimer;

    [HideInInspector] public int HP = 100; // public int HP { get; set; }

    void Update()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");

        if (HP <= 0 || redObjects == null)
            return;

        float closestDistance = Mathf.Infinity;
        GameObject closestRedObject = null;


        foreach (GameObject redObject in redObjects)
        {
            if (redObject != null)
            {
                float distance = Vector2.Distance(redObject.transform.position, transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestRedObject = redObject;
                }
            }
        }

        if (closestRedObject != null)
        {
            if (closestDistance > stoppingDistance)
            {
                float speed = 1.0f; // 이동 속도 설정
                Vector2 direction = (closestRedObject.transform.position - transform.position).normalized;
                transform.position += (Vector3)direction * speed * Time.deltaTime;

                animator.SetTrigger("doMove"); // 이동 애니메이션 재생
            }
        }

        foreach (GameObject redObject in redObjects)
        {
            if (redObject != null)
            {
                float distance = Vector2.Distance(redObject.transform.position, transform.position);    //가장 가까운 빨간색 객체로 향하는 방향을 나타내는 단위 벡터입니다.

                //distance <= minDistance && 
                if (distance <= stoppingDistance) // 멈춘 상태에서만 공격 가능하도록 조건 추가
                {
                    atkTimer += Time.deltaTime;
                    // 공격
                    if (atkTimer > atkTime)
                    {
                        atkTimer = 0;
                        redObject.GetComponent<Red_Tanker>().Hit(40);
                        animator.SetTrigger("doAttack"); // doAttack 애니메이션 실행
                    }
                }
            }
        }
    }

    public void Hit(int damage)
    {
        Debug.Log("Blue Attack");
        HP -= damage;   //데미지에 비례해서 hp 감소
        animator.SetTrigger("doHit");   //hit 애니메이션 실행

        if (HP <= 0)
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");   //doDie 애니메이션 실행
            Destroy(gameObject);    //객체 삭제
        }
    }
}
