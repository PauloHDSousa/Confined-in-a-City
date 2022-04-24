using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysTutorial : MonoBehaviour
{

    [SerializeField]
    SpriteRenderer up;

    [SerializeField]
    SpriteRenderer down;

    [SerializeField]
    SpriteRenderer left;

    [SerializeField]
    SpriteRenderer rigt;

    [SerializeField]
    SpriteRenderer click;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

            up.color = new Color(1f, 1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            down.color = new Color(1f, 1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            left.color = new Color(1f, 1f, 1f, 1f);
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            rigt.color = new Color(1f, 1f, 1f, 1f);
        }

        if (Input.GetMouseButtonDown(0))
        {
            click.color = new Color(1f, 1f, 1f, 1f);
        }


        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
        {

            up.color = new Color(1f, 1f, 1f, .5f);
        }

        if (Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            down.color = new Color(1f, 1f, 1f, .5f);
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            left.color = new Color(1f, 1f, 1f, .5f);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rigt.color = new Color(1f, 1f, 1f, .5f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            click.color = new Color(1f, 1f, 1f, .5f);
        }
    }
}
