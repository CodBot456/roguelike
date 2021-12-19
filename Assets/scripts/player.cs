using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour

{
    public Animator animator;
    public float speedX = 1;
    public float speedY = 1;
    public SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.D))
        {
            render.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            render.flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speedX * Time.deltaTime, 0, 0));
            animator.SetBool("isWalk", true);

        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speedX * Time.deltaTime, 0, 0));
            animator.SetBool("isWalk", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, speedY * Time.deltaTime, 0));
            animator.SetBool("isWalk", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, -speedY * Time.deltaTime, 0));
            animator.SetBool("isWalk", true);
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) //влево-вправо не двигаемся
        {
            animator.SetBool("isWalk", false);
        }
    }
}
