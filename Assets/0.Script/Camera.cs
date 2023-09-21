using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    bool left = false;
    bool right = false;

    [SerializeField] private GameObject BG1;
    [SerializeField] private GameObject BG2;
    [SerializeField] private GameObject BG3;
    void Update()
    {
        if (left == true)
        {
            if (transform.position.x <= 2f)
            {
                transform.Translate(new Vector2(Time.deltaTime * 1.6f, 0f));
                BG1.transform.Translate(new Vector2(Time.deltaTime * 1.4f, 0f));
                BG2.transform.Translate(new Vector2(Time.deltaTime * 1.1f, 0f));
                BG3.transform.Translate(new Vector2(Time.deltaTime * 0.8f, 0f));
            }

            else
            {
                left = false;
            }
        }

        if (right == true)
        {
            if (transform.position.x >= -2f)
            {
                transform.Translate(new Vector2(Time.deltaTime * -1.6f, 0f));
                BG1.transform.Translate(new Vector2(Time.deltaTime * -1.4f, 0f));
                BG2.transform.Translate(new Vector2(Time.deltaTime * -1.1f, 0f));
                BG3.transform.Translate(new Vector2(Time.deltaTime * -0.8f, 0f));
            }

            else
            {
                right = false;
            }
        }
    }

    public void Left_Button()
    {
        left = true;
    }

    public void Right_Button()
    {
        right = true;
    }
}
