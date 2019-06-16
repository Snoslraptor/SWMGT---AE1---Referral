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
    public float jumpHeight;
    private float airtime;
    //ground detection
    public Collider2D collision;
    


    private void Start()
    {
        my_rigid = GetComponent<Rigidbody2D>();
        moving = false;
        Jumping = false;
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
        //if(Input.GetKeyDown(KeyCode.S))



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
        else
            my_rigid.velocity = new Vector2(0, my_rigid.velocity.y);
    }

}
