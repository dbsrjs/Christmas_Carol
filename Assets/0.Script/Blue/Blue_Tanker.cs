using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Red_Tanker monster;
    [SerializeField] private Animator animator;

    GameObject[] redObjects;

    GameObject closestRedObject = null;
    float minDistance = Mathf.Infinity;

    float atkTime = 1.5f;    //공격 속도
    private float atkTimer;

    public int HP = 100; // public int HP { get; set; }

    IEnumerator Start()
    {
        redObjects = GameObject.FindGameObjectsWithTag("Red");
        yield return new WaitForSeconds(0.5f);
    }
    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 || redObjects == null)   //플레이어가 없거나 죽었을 때
            return;

        if (redObjects != null)
        {
            foreach (GameObject redObject in redObjects)
            {
                if (redObject != null)
                {
                    float distance = Vector2.Distance(redObject.transform.position, transform.position);
                    // 이제 distance 변수를 사용하여 필요한 작업을 수행할 수 있습니다.

                    if (distance <= minDistance)  //거리가 1 이하라면
                    {
                        closestRedObject = redObject;
                        minDistance = distance;

                        atkTimer += Time.deltaTime;
                        //공격
                        if (atkTimer > atkTime)
                        {
                            atkTimer = 0;
                            monster.Hit(40);
                            animator.SetTrigger("doAttack");    //doAttack 애니메이션 실행
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
