using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Animator animator;

    GameObject[] redObjects;

    GameObject closestRedObject = null;
    float minDistance = Mathf.Infinity;

    float atkTime = 1.5f;    //공격 속도
    private float atkTimer;

    public int HP = 100; // public int HP { get; set; }

    void Start()
    {
            redObjects = GameObject.FindGameObjectsWithTag("Red");
    }
    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 || redObjects == null)   //플레이어가 없거나 죽었을 때
            return;

        foreach (GameObject redObject in redObjects)
        {
            if (redObject != null)
            {                
                // 현재 오브젝트와의 거리를 계산합니다.
                float distance = Vector2.Distance(redObject.transform.position, transform.position);

                // 이 거리가 지금까지 찾은 최소 거리보다 작으면, 이 오브젝트와 그 거리를 저장합니다.
                if (distance <= minDistance)
                {
                    closestRedObject = redObject;
                    minDistance = distance;

                    atkTimer += Time.deltaTime;
                    //공격
                    if (atkTimer > atkTime)
                    {
                        atkTimer = 0;
                        redObject.GetComponent<Red_Tanker>().Hit(40);
                        animator.SetTrigger("doAttack");    //doAttack 애니메이션 실행
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

        // 가장 가까운 "Red" 태그를 가진 오브젝트로 이동하는 코드를 작성합니다.
        if (closestRedObject != null)
        {
            float speed = 1.0f; // 원하는 속도로 설정합니다.
            Vector2 direction = (closestRedObject.transform.position - transform.position).normalized;
            transform.position += (Vector3)direction * speed * Time.deltaTime;
            animator.SetTrigger("doMove");    //doMove 애니메이션 실행
        }
    }

    public void Hit(int damage)    //damage = power(Monster) = 10;
    {
        Debug.Log("Blue Attack");
        animator.SetTrigger("doHit");    //doHit 애니메이션 실행
        HP -= damage;   //HP 감소

        if (HP <= 0)    //죽었을 때
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");    //doDie 애니메이션 실행
            //yield return new WaitForSeconds(2f);    //2초 후
            Destroy(gameObject);    //몬스터 삭제
        }
    }
}
