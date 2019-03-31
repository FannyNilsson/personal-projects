using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour {
    bool onGround;
    float speed = 1.5f;
    public GameObject cameraObj;
    private RotateCamera rotCamInstance;

    // Use this for initialization
    void Start ()
    {
        rotCamInstance = FindObjectOfType<RotateCamera>();
    }
	
	// Update is called once per frame
	void Update ()
    {

        Vector3 pos = this.transform.localPosition;
        if (Input.GetKey("d"))
        {
            if(rotCamInstance.flipped == true)
            {
                pos.z += speed * Time.deltaTime;
            }
            else
            {
                pos.x += speed * Time.deltaTime;
            }
        }
        if (Input.GetKey("a"))
        {
            if (rotCamInstance.flipped == true)
            {
                pos.z -= speed * Time.deltaTime;
            }
            else
            {
                pos.x -= speed * Time.deltaTime;
            }
        }


        this.transform.localPosition = pos;

        //if object is touching the ground the object shall bounce up again
        if (onGround)
        {
            this.transform.Translate(Vector3.up * 5 * Time.deltaTime, Space.Self);
        }
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }
}
