using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temp_CamMovement : MonoBehaviour {
    Transform camT;
    [SerializeField]
    private float camMovementSpeed = 3.8f;
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
}
