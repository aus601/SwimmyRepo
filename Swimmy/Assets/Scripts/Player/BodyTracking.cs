using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* NEEDS POLISH. Still working on offsetting the body from the head so you aren't staring down your own neck
 * 
 * Makes the body follow the position and direction of the player head, but always remain vertical and upright.
 */
public class BodyTracking : MonoBehaviour
{
    public Rigidbody head;
    public Rigidbody headCenter;
    //public Rigidbody rig;
    private Vector3 bodyPos;

    private Quaternion prevRotation;
    private Vector3 eulerRotation;

    // Start is called before the first frame update
    void Start()
    {
        //fixedRotation = transform.rotation;
        //eulerRotation = transform.rotation.eulerAngles;

        bodyPos = new Vector3(0f, -0.25f, 0);
        
    }

    // Update is called once per frame
        //prevRotation = transform.rotation;
        //transform.rotation = Quaternion.Euler(0, prevRotation.y, prevRotation.z);
        //transform.rotation = fixedRotation.eulerAngles.x;

        /*
        headTransform = head.transform;
        headY = headTransform.position.y;

        transform.position = new Vector3(transform.position.x, headY, transform.position.z);
        */
    
    // Use LateUpdate instead of Update to avoid a lag/jerk effect
    private void LateUpdate()
    {
        transform.position = head.transform.position + bodyPos;
        prevRotation = head.transform.rotation;
        transform.rotation = Quaternion.Euler(0, prevRotation.eulerAngles.y, 0);
            //Quaternion.LookRotation(head.transform.rotation.eulerAngles, Vector3.up);
        //Quaternion.Euler(1.0f, prevRotation.y, prevRotation.z);
    }
}
