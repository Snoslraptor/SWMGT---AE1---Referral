using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //movement
    private Rigidbody2D my_rigid;
    public float speed;
    private bool moving;
    private bool right;
    //jumping
    private bool Jumping;
    private bool falling;
    public float jumpHeight;
    private float airtime;
    //ground detection
    public Collider2D collider2D;
    


    private void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        moving = false;
        Jumping = false;
        airtime = jumpHeight;
    }

    private void Update()
    {
        //--------------------------HORIZONTAL MOVEMENT---------------//
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            moving = true;

            if (Input.GetKeyDown(KeyCode.D))
                right = true;
            else
                right = false;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
            moving = false;

        //-----------------------------JUMPING----------------------//
        if (Input.GetKeyDown(KeyCode.W) && !Jumping && !falling)
        {
            Jumping = true;
            //allow for passing through floor
            if(collider2D.enabled == true)
                collider2D.enabled = !collider2D.enabled;
        }

        //limit the amount time spent gaining altitude
        if (Jumping)
        {
            airtime -= Time.deltaTime;
            if (airtime <= 0)
            {
                Jumping = false;
                //stop passing through floor
                if (collider2D.enabled == false)
                    collider2D.enabled = !collider2D.enabled;
                falling = true;
            }
        }

        //stop jumping, reset jumping time, turn collider back to normal
        if (Input.GetKeyUp(KeyCode.W))
        {
            Jumping = false;
            airtime = jumpHeight;
            if (collider2D.enabled == false)
                collider2D.enabled = !collider2D.enabled;
            if (falling == true)
                falling = false;
            else
                falling = true;
        }
    }

    private void FixedUpdate()
    {
        if (moving)
        {
            if (right)
                my_rigid.velocity = new Vector2(speed * Time.deltaTime, my_rigid.velocity.y);
            else
                my_rigid.velocity = new Vector2(-speed * Time.deltaTime, my_rigid.velocity.y);

        }
        else if (!moving)
            my_rigid.velocity = new Vector2(0, my_rigid.velocity.y);

        if (Jumping)
            my_rigid.velocity = new Vector2(my_rigid.velocity.x, speed * Time.deltaTime);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("You have collided with: " + collision);
        falling = false;
    }
}
