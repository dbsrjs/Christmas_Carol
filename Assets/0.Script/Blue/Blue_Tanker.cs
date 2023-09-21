using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blue_Tanker : MonoBehaviour
{
    [SerializeField] private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1, 0, 0) * 0.7f * Time.deltaTime;
        animator.SetTrigger("Move");
    }
}
