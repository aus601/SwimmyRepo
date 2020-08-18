using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class HoverUI : MonoBehaviour
{
    public Image collectSign;
    public Image trySign;
    public Rigidbody tank;
    Camera cam;

    private bool pickedUp;

    private void Awake()
    {
        pickedUp = false;
        collectSign.enabled = false;
        
    }

    private void Start()
    {
        cam = VRRigReference.instance.head.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            Vector3 tankPos = tank.transform.position;
            //Camera.main.WorldToScreenPoint(this.transform.position);
            trySign.enabled = false;
            collectSign.enabled = true;
            collectSign.transform.position = tankPos + new Vector3(0.9f, 0.9f, 0.2f);
            collectSign.transform.LookAt(cam.transform, new Vector3(0, 1, 0));
            //tank.AddTorque(new Vector3(5.0f, 1.0f, 1.0f));
        }
    }

    public void pickUp()
    {
        pickedUp = true;
    }

}