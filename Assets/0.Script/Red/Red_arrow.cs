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
}
