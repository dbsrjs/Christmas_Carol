using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_arrow : MonoBehaviour
{
    private float speed = 5;

    void Update()
    {
        Vector3 vec = Vector3.left * speed * Time.deltaTime;
        transform.position += vec;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Blue>())   //Blue와 출돌
        {
            collision.GetComponent<Blue>().Hit(20); //20
        }

        else if (collision.GetComponent<Blue_Base>()) //Blue_Base와 출돌
        {
            collision.GetComponent<Blue_Base>().Hit(5);
        }

        Destroy(gameObject);
    }
}
