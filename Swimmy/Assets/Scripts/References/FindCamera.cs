using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FindCamera : MonoBehaviour
{
    //public Camera lobbyCam;
    //public Camera gameCam;

    void Start()
    {
        this.GetComponent<Canvas>().worldCamera = VRRigReference.instance.head.GetComponent<Camera>();

        /*
        lobbyCam = GameObject.Find("Lobby Camera").GetComponent<Camera>();
        gameCam = GameObject.Find("Game Camera").GetComponent<Camera>();

        lobbyCam.enabled = true;
        gameCam.enabled = false;
        */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
