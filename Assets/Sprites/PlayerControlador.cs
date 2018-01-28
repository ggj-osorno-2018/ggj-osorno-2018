using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControlador : MonoBehaviour {
    public float maxSpeed = 5f;
    public float speed = 2f;
    public bool grounded;
    public bool grounded2;
    public float jumpPower = 6.5f;
    public int daño = 0;
  

    private Animator anim;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    private bool jump;
    private bool doubleJump;
    private bool movement = true;

    public GameObject enemigo1;
    public GameObject enemigo2;
    private GameObject barravida;
    public GameObject hacha;
    public Animator hachan;
    public bool agachado;
   
    // Use this for initialization
    void Start() {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
       
        barravida = GameObject.Find("BarraDeVida");
    }

    // Update is called once per frame
    void Update() {
        anim.SetFloat("speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounder", grounded);
        anim.SetBool("Grounder2", grounded2);

        if (grounded)
        {
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (grounded) {

                jump = true;
                doubleJump = true;
            } else if (doubleJump)
            {
                jump = true;

                doubleJump = false;
            }
        }
        
        if (grounded2)
        {
            doubleJump = true;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (grounded2)
            {

                jump = true;
                doubleJump = true;
            }
            else if (doubleJump)
            {
                jump = true;

                doubleJump = false;
            }
        }




    }
    void FixedUpdate() {
        Vector3 fixedVelocity = rb2d.velocity;
        Vector3 fixedVelocity2 = rb2d.velocity;
        fixedVelocity.x *= 0.75f;
        fixedVelocity2.x *= 12f;

        if (Input.GetKey("x"))
        {
            anim.SetBool("ataque", true);
        }
        else
        {
            anim.SetBool("ataque", false);
        }


        if (grounded)
        {
            rb2d.velocity = fixedVelocity;
        }
        if (grounded2)
        {
            rb2d.velocity = fixedVelocity2;
        }
        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        rb2d.AddForce(Vector2.right * speed * h);
        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if (h > 0.1f) {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            
        }
            
       
        if (jump)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }
    
        
    }
    


    public void EnemyJump()
    {
        jump = true;
    }
    
    public void EnemyKnockBack(float enemyPostX)

    {


        barravida.SendMessage("TakeDamage", 10);
        jump = true;
            float side = Mathf.Sign(enemyPostX - transform.position.x);
            rb2d.AddForce(Vector2.left * side * jumpPower, ForceMode2D.Impulse);
            movement = false;
            Invoke("EnableMovement", 0.7f);
            spr.color = Color.red;
       

    }
   

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;

    }
}
