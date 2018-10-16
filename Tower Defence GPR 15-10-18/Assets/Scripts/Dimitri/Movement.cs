using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D player;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private float groundedDistance;
    [SerializeField]
    private LayerMask ground;

    private void Awake()
    {
        player = GetComponent<Rigidbody2D>();
    }

    public bool CheckGrounded()
    {
        return Physics2D.Raycast(transform.position, -Vector2.up, groundedDistance, ground);
    }

    void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
	}

    private void Jump()
    {
        player.AddForce(transform.up * jumpHeight, ForceMode2D.Impulse);
    }

    private void MoveRight()
    {
        player.AddForce(transform.right * movementSpeed);
    }

    private void MoveLeft()
    {
        player.AddForce(-transform.right * movementSpeed);
    }
}
