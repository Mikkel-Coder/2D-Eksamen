using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float Speed;
    public float JumpPower;

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
        Vector2 movement = new Vector2(0, RB.velocity.y);

        //Input til spiller nummer 2
        if (Input.GetKey(KeyCode.J))
        {
            movement.x = -Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            movement.x = Speed * Time.deltaTime;
        }

        // hop kun hvis tasten og spilleren står på jorden
        if (Input.GetKeyDown(KeyCode.I) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
            source.Play();
        }

        RB.velocity = movement;
    }

    //tjeker om spilleren står på jorden
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
}