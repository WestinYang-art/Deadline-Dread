using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerScript : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float multiplier;
    public float health;
    public Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private bool canDash = true;
    private float dashTime;
    //private Animator animator;

    
    void Awake()
    {
        //animator = GetComponent<Animator>();
        this.maxSpeed = SceneSwitchManager.getMaxSLvl() * 3;
        this.acceleration = SceneSwitchManager.getAccelLvl() * 2;
        this.health = SceneSwitchManager.getHealthLvl();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && canDash)
        {
            rb.velocity = new Vector2(horizontal * acceleration * multiplier, vertical * acceleration * multiplier);
            canDash = false;
            dashTime = Time.fixedDeltaTime;
        }
        else if (dashTime + 2 > Time.fixedDeltaTime)
        {
            canDash = true;
        }
    }

    private void FixedUpdate()
    {
        move();
        getInput();
        //lookPretty();
    }

    private void getInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
    }

    /*private void lookPretty()
    {
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        bool sideways = Math.Abs(horiz) > Math.Abs(vert);
        bool moving = Math.Max(Math.Abs(horiz), Math.Abs(vert)) > 0.01f;
        bool upways = vert > 0;

        animator.SetBool("sideways", sideways);
        animator.SetBool("moving", moving);
        animator.SetBool("upways", upways);

        if(horiz>0 && sideways) transform.localScale = new Vector3(-1, 1, 1);
        else transform.localScale = new Vector3(1, 1, 1);
    }*/

    private void move()
    {
        if (rb.velocity.x == 0 && (horizontal == -1 || horizontal == 1))
        {
            rb.velocity = new Vector2(horizontal * acceleration, rb.velocity.y);
        }
        else if (horizontal == -1 && rb.velocity.x > (0 - maxSpeed))
        {
            rb.velocity = new Vector2(rb.velocity.x - acceleration, rb.velocity.y);
        }
        else if (horizontal == 1 && rb.velocity.x < maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x + acceleration, rb.velocity.y);
        }

        if (rb.velocity.y == 0 && (vertical == -1 || vertical == 1))
        {
            rb.velocity = new Vector2(rb.velocity.x, vertical * acceleration);
        }
        else if (vertical == -1 && rb.velocity.y > (0 - maxSpeed))
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - acceleration);
        }
        else if (vertical == 1 && rb.velocity.y < maxSpeed)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + acceleration);
        }

        if (horizontal == 0)
        {
            if (rb.velocity.x > 0 && rb.velocity.x >= acceleration)
            {
                rb.velocity = new Vector2(rb.velocity.x - (acceleration / 2), rb.velocity.y);
            }
            else if (rb.velocity.x < 0 && rb.velocity.x <= 0 - acceleration)
            {
                rb.velocity = new Vector2(rb.velocity.x + (acceleration / 2), rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        }

        if (vertical == 0)
        {
            if (rb.velocity.y > 0 && rb.velocity.y >= acceleration)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - (acceleration / 2));
            }
            else if (rb.velocity.y < 0 && rb.velocity.y <= 0 - acceleration)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + (acceleration / 2));
            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
        }
    }
}







