using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {

    public GameObject Camera;
    private Vector3 floorPos;
    private Vector3 pos;
    private Vector3 floorScale;
    private Vector3 scale;
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.eulerAngles = new Vector3 (0f,0f,0f);
        Vector3 camPos = Camera.gameObject.transform.position;
        Vector3 pos = gameObject.transform.position;
		if (Input.GetKey(KeyCode.W) == true)
        {
            if (pos.x <= 149)
            {
                pos.x += 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.S) == true)
        {
            if (pos.x >= -149)
            {
                pos.x -= 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.A) == true)
        {
            if (pos.z < 99)
            {
                pos.z += 0.1f;
            }
        }
        if (Input.GetKey(KeyCode.D) == true)
        {
            if (pos.z > -99)
            {
                pos.z -= 0.1f;
            }
        }
        gameObject.transform.position = pos;
        Camera.gameObject.transform.position = camPos;
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            floorPos = collision.gameObject.transform.position;
            pos = gameObject.transform.position;
            floorScale = collision.gameObject.transform.localScale;
            scale = gameObject.transform.localScale;
            
            if ((floorPos.y + (floorScale.y / 2))-(pos.y - (scale.y / 2)) < 2)
            {
                pos.y = (floorPos.y + (floorScale.y / 2)) + (scale.y);
            }
            gameObject.transform.position = pos;
        } 
    }
}
