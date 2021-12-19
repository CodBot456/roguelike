using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dangerous_Enemy : MonoBehaviour
{
    public Animator animator;
    public GameObject target;
    public float step;
    public float speed;
    public float distance;
    public float stopDistance;
    public float atakDistance;
    public float timer = 0;
    public float attackTimer = 4.5f;
    public LayerMask mask;
    public damage ghostDamage;
    public health ghostHealth;
    public float territory_distance;
    public Vector2 start_position;
    Vector2 dot;
    float up;
    float down;
    float left;
    float right;
    public SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        start_position = transform.position;
        up = (start_position.y + territory_distance);
        down = (start_position.y - territory_distance);
        left = (start_position.x - territory_distance);
        right = (start_position.x + territory_distance);
        animator = GetComponent<Animator>();
        attackTimer = 4.5f;
        timer = 0;
        ghostDamage = GetComponent<damage>();
        ghostHealth = GetComponent<health>();
        dot = new Vector2(Random.Range(left, right), Random.Range(down, up));
        render = GetComponent<SpriteRenderer>();
    }
    public void atack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(transform.position,3,mask);
        foreach (Collider2D collider in enemies)
        {
            if (collider.gameObject.tag == "Player")
            {
                health playerHealth = collider.gameObject.GetComponent<health>();
                playerHealth.valueOfHealth -= ghostDamage.valueOfDamage;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if (Vector2.Distance(transform.position, dot) < 0.001f)
        {
            dot = new Vector3(Random.RandomRange(left, right), Random.RandomRange(down, up), 0);
        }
        //print(Vector3.Magnitude(transform.position - target.transform.position));
        if (Vector3.Magnitude(transform.position - target.transform.position) < distance)
        {
            if (Vector3.Magnitude(transform.position - target.transform.position) >= stopDistance)
            {
                step = speed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
                if (transform.position.x < target.transform.position.x)
                {
                    render.flipX = false;
                }
                else
                {
                    render.flipX = true;
                }
            }
        }
        else
        {

            transform.position = Vector2.MoveTowards(transform.position, dot, Time.deltaTime * speed);
            if (transform.position.x < dot.x)
            {
                render.flipX = false;
            }
            else
            {
                render.flipX = true;
            }
        }
        if (Vector3.Magnitude(transform.position - target.transform.position) <= atakDistance)
        {
            if (timer >= attackTimer)
            {
                timer = 0;
                animator.SetTrigger("atack");
            }
        }

        if (ghostHealth.valueOfHealth <= 0)
            {
                Destroy(gameObject);
            }
    }
}
