using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovePlayer : MonoBehaviour {

    public float speed = 5f;             //Floating point variable to store the player's movement speed.

    private Rigidbody2D rb2d;       //Store a reference to the Rigidbody2D component required to use 2D Physics.

    Animator anim;
    public Animator Golpe;

    // Use this for initialization
    void Start()
    {

        //Get and store a reference to the Rigidbody2D component so that we can access it.
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    //FixedUpdate is called at a fixed interval and is independent of frame rate. Put physics code here.
    void FixedUpdate()
    {
        //Store the current horizontal input in the float moveHorizontal.
        float moveHorizontal = Input.GetAxis("Horizontal");

        //Store the current vertical input in the float moveVertical.
        float moveVertical = Input.GetAxis("Vertical");
        

        //Use the two store floats to create a new Vector2 variable movement.
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if(moveHorizontal > 0)
        {
            anim.SetBool("walking", true);
            anim.SetBool("ataque", false);
            transform.localScale = new Vector2(1f, 1f);
        }

        if (moveHorizontal < 0)
        {
            anim.SetBool("walking", false);
            anim.SetBool("ataque", false);
            transform.localScale = new Vector2(-1f, 1f);
        }

        if (Input.GetKey("x"))
        {
            anim.SetBool("ataque", true);
        }
        else
        {
            anim.SetBool("ataque", false);
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {

        }

        //Call the AddForce function of our Rigidbody2D rb2d supplying movement multiplied by speed to move our player.
        rb2d.AddForce(movement * speed);

        
    }
}
