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
    private BoxCollider2D playerBoxCollider;
    private string facingDirection;
    private bool isAbleToMove = true;
    private float attackTimer;
   // private AiUnit scriptReferenceEnemy;
    [SerializeField]
    private LayerMask enemyLayer;
    [SerializeField]
    private float checkDistance;
	private void Start () {
        playerT = GetComponent<Transform>();
        playerAnimator = GetComponent<Animator>();
        playerBoxCollider = GetComponent<BoxCollider2D>();
        facingDirection = "down";
	}	
	private void Update () {
        MovePlayer();
	}

    private void MovePlayer()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AnimateAttack();
            isAbleToMove = false;
            GameObject enemy = PlayerAttack();
            if (enemy != null)
            {
                Debug.Log("oef");
                //scriptReferenceEnemy = enemy.GetComponent<AiUnit>();
            }
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

    private GameObject PlayerAttack()
    {
        RaycastHit2D enemyHit;
        if (facingDirection == "up")
        {
            enemyHit = Physics2D.Raycast(transform.position, Vector2.up, checkDistance, enemyLayer);
        }
        else if (facingDirection == "left")
        {
            enemyHit = Physics2D.Raycast(transform.position, Vector2.left, checkDistance, enemyLayer);
        }
        else if (facingDirection == "down")
        {
            enemyHit = Physics2D.Raycast(transform.position, Vector2.down, checkDistance, enemyLayer);
        }
        else// this is right
        {
            enemyHit = Physics2D.Raycast(transform.position, Vector2.right, checkDistance, enemyLayer);
        }
        return enemyHit.transform.gameObject;
    }

    private void AnimateAttack()
    {
        if (facingDirection == "up")
        {
            playerAnimator.Play("AttackUp");
        }
        else if (facingDirection == "left")
        {
            playerAnimator.Play("AttackLeft");
        }
        else if (facingDirection == "down")
        {
            playerAnimator.Play("AttackDown");
        }
        else// this is right
        {
            playerAnimator.Play("AttackRight");
        }
    }
}
