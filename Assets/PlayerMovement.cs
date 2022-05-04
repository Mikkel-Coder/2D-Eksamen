using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpPower;
    public Animator PlayerAnimatior;
    public SpriteRenderer SR;

    private Rigidbody2D RB;

    private bool _isGrounded;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //vektor dannes og gives værdierne...
        Vector2 movement = new Vector2(0,RB.velocity.y);

        //input til spiller nummer et
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = Speed * Time.deltaTime;
        }
        // hop kun hvis tasten og spilleren står på jorden
        if (Input.GetKeyDown(KeyCode.W) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
            source.Play();
        }
        
        //Når spilleren bevæger sig
        if (movement.x != 0)
        {
            PlayerAnimatior.SetBool("IsMoving", true);
        }
        else
        {
            PlayerAnimatior.SetBool("IsMoving", false);
        }
        
        if (movement.x > 0)
        {
            SR.flipX = false;
        }
        else
        {
            SR.flipX = true;
        }

        //opdatere movemnt til at passe overens
        RB.velocity = movement;


    }
    // tjekker om spilleren står på jorden
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

}
