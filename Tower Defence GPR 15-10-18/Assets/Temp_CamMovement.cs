using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_CamMovement : MonoBehaviour {
    Transform camT;
    float camMovementSpeed = 3.8f;
	// Use this for initialization
	void Start () {
        camT = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        CamMovement();
	}

    private void CamMovement()
    {
         if (camT.transform.position.y < -4.522024f)
         {
        if (Input.GetKey(KeyCode.W))
            {
                camT.transform.Translate(0, camMovementSpeed * Time.deltaTime, 0);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            camT.transform.Translate(-camMovementSpeed * 1.5f * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            camT.transform.Translate(0, -camMovementSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            camT.transform.Translate(camMovementSpeed * 1.5f * Time.deltaTime, 0, 0);
        }
    }
}
