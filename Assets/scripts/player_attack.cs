using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public Animator animator;
    public LayerMask mask;
    public damage enemyDamage;
    public GameObject re;
    public GameObject le;
    public float speedX = 1;
    public SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            animator.SetTrigger("isAttack");

        }
        
    }
    public void atack_2()
    {
        Collider2D[] enemies;

        if (render.flipX == true)
        {
            enemies = Physics2D.OverlapCircleAll(le.transform.position, 1, mask);
        }
    else
        enemies = Physics2D.OverlapCircleAll(re.transform.position, 1, mask);
        foreach (Collider2D collider in enemies)
        {
            if (collider.gameObject.tag == "danger")
            {
                damage playerDamage = gameObject.GetComponent<damage>();
                health enemyHealth = collider.gameObject.GetComponent<health>();
                enemyHealth.valueOfHealth -= playerDamage.valueOfDamage;
            }

        }
    }
}
