using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bool_slaym : MonoBehaviour
{
    public GameObject target;
    public float speed;
    public float distance;
    public float stopDistance;
    public float atakDistance;
    public float timer = 0;
    public Animator animator;
    public float reload_timer = 3;
    public float step;
    Vector3 cords;
    bool isActive;
    Vector2 dot;
    float up;
    float down;
    float left;
    float right;
    public SpriteRenderer render;
    public float territory_distance;
    public Vector2 start_position;
    public float dotTimer;
    public void startEnd()
    {
        animator.SetBool("isStart", false);
        animator.SetBool("isBool2", true);
    }
    public void bool2End()
    {
        animator.SetBool("isBool2", false);
        animator.SetBool("isCikel", true);
    }
    // Start is called before the first frame update
    void Start()
    {
        start_position = transform.position;
        up = (start_position.y + territory_distance);
        down = (start_position.y - territory_distance);
        left = (start_position.x - territory_distance);
        right = (start_position.x + territory_distance);
        dot = new Vector2(Random.Range(left, right), Random.Range(down, up));
        render = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Vector2.Distance(transform.position, dot) < 0.001f && dotTimer >= 3)
        {
            dot = new Vector3(Random.RandomRange(left - 3, right + 3), Random.RandomRange(down, up), 0);
            dotTimer = 0;
        }
        else
        {
            dotTimer += Time.deltaTime;
        }
        if (Vector2.Distance(transform.position, target.transform.position) <= atakDistance && timer >= reload_timer) 
        {

            if (isActive == false)
            {
                animator.SetBool("isStart", true);
                cords = target.transform.position - ((transform.position - target.transform.position).normalized * 5f);
                isActive = true;

            }
            step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, cords,step);
            if (Vector2.Distance(transform.position, cords) < 0.0001)
            {
                animator.SetBool("isStart", false);
                animator.SetBool("isBool2", false);
                animator.SetBool("isCikel", false);
                timer = 0;
                isActive = false;

            }

        }



        if (Vector3.Magnitude(transform.position - target.transform.position) >= atakDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, dot, Time.deltaTime * speed/5);
            if (transform.position.x < dot.x)
            {
                render.flipX = true;
            }
            else
            {
                render.flipX = false;
            }
        }
    
        else
        {
            if (transform.position.x < target.transform.position.x)
            {
                render.flipX = true;
            }
            else
            {
                render.flipX = false;
            }

        }
    }
}
