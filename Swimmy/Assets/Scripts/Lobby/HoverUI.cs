using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

/* Makes the Image UI elements hover above the object and face player camera
 * Used only on the oxygenTank in Lobby Scene
 */
public class HoverUI : MonoBehaviour
{
    public Image collectSign;
    public Image trySign;
    public Image successSign;
    public Rigidbody tank;
    private Transform cam;

    //0 = untouched/static. 1 = held in hand. 2 = dropped from hand
    private int pickedUp;

    private bool handInBag;
    private bool droppedInBag;

    private void Awake()
    {
        pickedUp = 0;
        collectSign.enabled = false;
        successSign.enabled = false;
        droppedInBag = false;
        handInBag = false;
        
    }

    private void Start()
    {
        cam = VRRigReference.instance.head;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tankPos = tank.transform.position;
        //Vector3 relativeOffset = tankPos + transform.TransformPoint(new Vector3(0.7f, 0.9f, 0.0f));

        if (pickedUp == 1)
        {
            trySign.enabled = false;
            collectSign.enabled = true;

            collectSign.transform.position = tankPos + new Vector3(0.0f, 0.6f, 0.0f);
            //collectSign.transform.position = new Vector3(relativeOffset.x, tankPos.y + 0.5f, tankPos.z);
            collectSign.transform.LookAt(cam.transform, new Vector3(0, 1, 0));
            
            tank.AddForce(new Vector3(1.0f, 1.0f, 1.0f));
        }
        else if (pickedUp == 2)
        {
            trySign.enabled = true;
            collectSign.enabled = false;

            trySign.transform.position = tankPos + new Vector3(0.0f, 0.8f, 0.0f);
            //trySign.transform.position = new Vector3(relativeOffset.x, tankPos.y + 0.5f, relativeOffset.z);
            trySign.transform.LookAt(cam.transform, new Vector3(0, 1, 0));
        }
        else if (droppedInBag)
        {
            trySign.enabled = false;
            collectSign.enabled = false;

            successSign.enabled = true;
            successSign.transform.position = tankPos + new Vector3(0.0f, 0.8f, 0.0f);
            successSign.transform.LookAt(cam.transform, new Vector3(0, 1, 0));

            tank.GetComponent<MeshRenderer>().enabled = false;
        }

    }

    // Object being held in hand
    public void pickUp()
    {
        pickedUp = 1;
    }

    public void dropped()
    {
        if (handInBag)
        {
            //Object was dropped inside the bag
            droppedInBag = true;
        }
        else
        {
            //Object was dropped after being picked up before
            pickedUp = 2;
        }
        
    }

    /* Check if hand 
     * 
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bag")
            handInBag = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Bag")
            handInBag = false;
    }

}