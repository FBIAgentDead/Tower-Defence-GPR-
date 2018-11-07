using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_CamMovement : MonoBehaviour {
    Transform camT;
    [SerializeField]
    private float camMovementSpeed = 3.8f;
    PlayerScript PlayerReference;
	// Use this for initialization
	void Start () {
        camT = GetComponent<Transform>();
        PlayerReference = GameObject.Find("Player_Knight").GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            BorderCamera();
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
        if (Input.GetKey(KeyCode.A) && camT.transform.position.x > 8.3715)
        {
            camT.transform.Translate(-camMovementSpeed * 1.5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S) && camT.transform.position.y > -10.58793)
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
            Vector3 playerVector3 = PlayerReference.playerT.position;
            Vector3 camVector3 = camT.position;
            Vector3 diffBetweenCamAndPlayer = camVector3 - playerVector3;
            camT.Translate(-diffBetweenCamAndPlayer.x * Time.deltaTime * 1.9f, -diffBetweenCamAndPlayer.y * Time.deltaTime * 1.9f, 0);
    }

    private void BorderCamera()
    {

    }
}
