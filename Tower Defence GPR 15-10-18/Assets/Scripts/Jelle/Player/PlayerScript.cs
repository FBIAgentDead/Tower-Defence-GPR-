using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {
    public Transform playerT;
    [SerializeField]
    private float playerMovementSpeed;
    [SerializeField]
    private float attackTimeCap;
    private Animator playerAnimator;
    private string facingDirection;
    private bool isAbleToMove = true;
    private float attackTimer;
	private void Start () {
        playerT = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        facingDirection = "down";
	}	
	private void Update () {
        MovePlayer();
	}

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerAttack();
            isAbleToMove = false;
        }
        else if (Input.GetKey(KeyCode.W) && isAbleToMove && playerT.position.y < 0.7f)
        {
            playerT.Translate(0,playerMovementSpeed * Time.deltaTime,0);
            playerAnimator.Play("UpAnim");
            facingDirection = "up";
        }
        else if (Input.GetKey(KeyCode.A) && isAbleToMove && playerT.position.x > -0.1f)
        {
            playerT.Translate(-playerMovementSpeed * Time.deltaTime, 0,0);
            playerAnimator.Play("LeftAnim");
            facingDirection = "left";
        }
        else if (Input.GetKey(KeyCode.S) && isAbleToMove && playerT.position.y > -14.3f)
        {
            playerT.Translate(0, -playerMovementSpeed * Time.deltaTime, 0);
            playerAnimator.Play("DownAnim");
            facingDirection = "down";
        }
        else if (Input.GetKey(KeyCode.D) && isAbleToMove && playerT.position.x < 36.1f)
        {
            playerT.Translate(playerMovementSpeed * Time.deltaTime, 0, 0);
            playerAnimator.Play("RightAnim");
            facingDirection = "right";
        }
        else if (isAbleToMove)
        {
            playerAnimator.Play("IdleAnim");
        }


        if (!isAbleToMove)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer > attackTimeCap)
            {
                isAbleToMove = true;
                attackTimer = 0;
            }
        }

    }

    private void PlayerAttack()
    {
        switch (facingDirection)
        {
            case "up":
                playerAnimator.Play("AttackUp");
                break;
            case "left":
                playerAnimator.Play("AttackLeft");
                break;
            case "down":
                playerAnimator.Play("AttackDown");
                break;
            case "right":
                playerAnimator.Play("AttackRight");
                break;
        }
    }
}
