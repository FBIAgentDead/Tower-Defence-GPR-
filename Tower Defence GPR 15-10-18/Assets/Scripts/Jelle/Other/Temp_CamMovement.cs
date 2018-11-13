using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_CamMovement : MonoBehaviour {
    [SerializeField]
    private float moveToPlayerSpeed;
    Transform camT;
    [SerializeField]
    private float camMovementSpeed = 3.8f;
    PlayerScript PlayerReference;
    // Use this for initialization
    void Start () {
        camT = GetComponent<Transform>();
        PlayerReference = GameObject.Find("Player_Knight").GetComponent<PlayerScript>();
        moveToPlayerSpeed = moveToPlayerSpeed/10;
	}
	
	// Update is called once per frame
	void Update () {
        BorderCamera();
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            LockOnPlayer();
        }
        else
        {
            CamMovement();
        }
	}

    private void CamMovement()
    {
        if (Input.GetKey(KeyCode.W) && camT.transform.position.y < -4.522024f)
        {
            camT.transform.Translate(0, camMovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.A) && camT.transform.position.x > 8.3715f)
        {
            camT.transform.Translate(-camMovementSpeed * 1.5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && camT.transform.position.y > -10.58793f)
        {
            camT.transform.Translate(0, -camMovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D) && camT.transform.position.x < 27.63964f)
        {
            camT.transform.Translate(camMovementSpeed * 1.5f * Time.deltaTime, 0, 0);
        }
    }

    private void LockOnPlayer()
    {
            camT.position = new Vector3(Mathf.Lerp(camT.position.x, PlayerReference.playerT.position.x, 0.1f * moveToPlayerSpeed), Mathf.Lerp(camT.position.y, PlayerReference.playerT.position.y, 0.1f * moveToPlayerSpeed), camT.position.z);
    }

    private void BorderCamera()
    {
        if (camT.transform.position.y > -4.501292f)
        {
            camT.position = new Vector3(camT.position.x, -4.501292f, camT.position.z);
        }
        if (camT.transform.position.y < -10.58793f)
        {
            camT.position = new Vector3(camT.position.x, -10.58793f, camT.position.z);
        }
        if (camT.transform.position.x < 8.3715f)
        {
            camT.position = new Vector3(8.3715f, camT.position.y, camT.position.z);
        }
        if (camT.transform.position.x > 27.63964f)
        {
            camT.position = new Vector3(27.63964f, camT.position.y, camT.position.z);
        }
    }
}
