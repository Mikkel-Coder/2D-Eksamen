using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpPower;

    private Rigidbody2D RB;

    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

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
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded == true)
        {
            RB.AddForce(new Vector2(0, JumpPower));
            _isGrounded = false;
        }

        RB.velocity = movement;
    }
    // tjekker om spilleren står på jorden
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }

}
