using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_arrow : MonoBehaviour
{
    private float speed = 5;

    void Update()
    {
        Vector3 vec = Vector3.right * speed * Time.deltaTime;
        transform.position += vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("test");
        if (collision.GetComponent<Red>())   //Red와 출돌
        {
            collision.GetComponent<Red>().Hit(20); //20
        }

        else if(collision.GetComponent<Red_Base>()) //Red_Base와 출돌
        {
            collision.GetComponent<Red_Base>().Hit(5);
        }

        Destroy(gameObject);
    }
}
