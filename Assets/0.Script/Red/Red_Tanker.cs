using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Tanker : MonoBehaviour
{
    [SerializeField] private Blue_Tanker p;
    [SerializeField] private Animator animator;

    GameObject[] blueObjects;

    GameObject closestRedObject = null;
    float minDistance = Mathf.Infinity;

    float atkTime = 1.6f;    //공격 속도

    [HideInInspector] public int hp = 100;   //채력

    private float atkTimer;

    // Update is called once per frame

    IEnumerator Start()
    {
        blueObjects = GameObject.FindGameObjectsWithTag("Blue");
        yield return new WaitForSeconds(0.5f);
    }
    void Update()
    {
        if (p == null || hp <= 0 || blueObjects == null)   //플레이어가 없거나 죽었을 때
            return;

        if (blueObjects != null)
        {
            foreach (GameObject blueObject in blueObjects)
            {
                if (blueObject != null)
                {
                    float distance = Vector2.Distance(blueObject.transform.position, transform.position);
                    // 이제 distance 변수를 사용하여 필요한 작업을 수행할 수 있습니다.

                    if (distance <= minDistance)  //거리가 1 이하라면
                    {
                        closestRedObject = blueObject;
                        minDistance = distance;

                        atkTimer += Time.deltaTime;
                        //공격
                        if (atkTimer > atkTime)
                        {
                            atkTimer = 0;
                            blueObject.GetComponent<Blue_Tanker>().Hit(10);
                        }
                    }

                    else
                    {
                        if (closestRedObject != null)
                        {
                            animator.SetTrigger("doMove");    //doMove 애니메이션 실행
                            float speed = 0.3f;
                            Vector2 direction = (closestRedObject.transform.position - transform.position).normalized;
                            transform.position += (Vector3)direction * speed * Time.deltaTime;
                        }
                    }
                }
            }
        }
    }

    public void Hit(int damage)
    {
        Debug.Log("Red Attack");
        hp -= damage;   //데미지에 비례해서 hp 감소
        animator.SetTrigger("doHit");    //hit 애니메이션 실행

        if (hp <= 0)    //죽으면
        {
            Destroy(GetComponent<Rigidbody2D>());   //Rigidbody2D 삭제
            animator.SetTrigger("doDie");    //doDie 애니메이션 실행            
            Destroy(gameObject);    //객체 삭제
        }
    }
}
