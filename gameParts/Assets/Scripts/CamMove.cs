using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour {

    public GameObject cam;
    public GameObject D;
    private Vector3 pos;
    private Vector3 Dpos;
    private bool hit = false;
    private Vector3 angle;
    private float difference;
	
	// Update is called once per frame
	void Update ()
    {
        Dpos = D.gameObject.transform.position; // Damian's place
        pos = gameObject.transform.position; // Pointer's place

        difference = Dpos.x - pos.x;

        if (hit == false)
        {
            pos.x = Dpos.x - 6; //setting the pointer at the right distance
        }
        else
        {
            if ((difference) >= 6)
            {
                hit = false; //when the distance is back to normal
            }
        }

        pos.z = Dpos.z; //always the same y and z
        pos.y = Dpos.y + 3;

        gameObject.transform.position = pos; //move pointer
        cam.gameObject.transform.position = pos;  //move camera w/it

        if ((difference) <= 3.5) //angle changing
        {
            angle = cam.gameObject.transform.eulerAngles;
            angle.x = (((3.5f - difference) * 10) + 15);
            cam.gameObject.transform.eulerAngles = angle;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            hit = true;
        }
    }
}
