using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed;
    public float JumpPower;

    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(0,RB.velocity.y);

        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -Speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = Speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RB.AddForce(new Vector2(0, JumpPower));
        }

        RB.velocity = movement;



    }
}
