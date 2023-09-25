using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public bool left = false;
    public bool right = false;

    [SerializeField] private GameObject BG1;
    [SerializeField] private GameObject BG2;
    [SerializeField] private GameObject BG3;

    void Update()
    {
        if (left == true && transform.position.x >= -2f)
        {
            transform.Translate(new Vector2(Time.deltaTime * -1.7f, 0f));
            BG1.transform.Translate(new Vector2(Time.deltaTime * -1.5f, 0f));
            BG2.transform.Translate(new Vector2(Time.deltaTime * -1.2f, 0f));
            BG3.transform.Translate(new Vector2(Time.deltaTime * -0.9f, 0f));
        }

        if (right == true && transform.position.x <= 2f)
        {
            transform.Translate(new Vector2(Time.deltaTime * 1.7f, 0f));
            BG1.transform.Translate(new Vector2(Time.deltaTime * 1.5f, 0f));
            BG2.transform.Translate(new Vector2(Time.deltaTime * 1.2f, 0f));
            BG3.transform.Translate(new Vector2(Time.deltaTime * 0.9f, 0f));
        }
    }
}
