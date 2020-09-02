using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class SwimArmMotion : MonoBehaviour
{
    //Game objects
    public GameObject LeftHand;
    public GameObject RightHand;
    public GameObject CenterEyeCamera;
    public GameObject ForwardDirection;

    private Vector3 PositionPreviousFrameLeftHand;
    private Vector3 PositionPreviousFrameRightHand;
    private Vector3 PlayerPositionPreviousFrame;
    private Vector3 PlayerPositionThisFrame;
    private Vector3 PositionThisFrameLeftHand;
    private Vector3 PositionThisFrameRightHand;

    public float Speed = 70;
    private float HandSpeed;

    //Start is called before first frame update
    void Start()
    {
        PlayerPositionPreviousFrame = transform.position;
        PositionPreviousFrameLeftHand = LeftHand.transform.position;
        PositionPreviousFrameRightHand = RightHand.transform.position;
    }

    //Update is called once per frame
    void Update()
    {
        //Get forward direction from center eye camera, set it to forward direction Game Object
        
        float xRotation = CenterEyeCamera.transform.eulerAngles.x;
        float yRotation = CenterEyeCamera.transform.eulerAngles.y;
        float zRotation = CenterEyeCamera.transform.eulerAngles.z;
        ForwardDirection.transform.eulerAngles = new Vector3(xRotation, yRotation, zRotation); 

        //Get CURRENT positions of hands and player
        PositionThisFrameLeftHand = LeftHand.transform.position;
        PositionThisFrameRightHand = RightHand.transform.position;
        PlayerPositionThisFrame = transform.position;

        //Get distance moved since last frame
        float playerDistanceMoved = Vector3.Distance(PlayerPositionThisFrame, PlayerPositionPreviousFrame);
        float leftHandDistanceMoved = Vector3.Distance(PositionPreviousFrameLeftHand, PositionThisFrameLeftHand);
        float rightHandDistanceMoved = Vector3.Distance(PositionPreviousFrameRightHand, PositionThisFrameRightHand);

        /*
        //Get forward direction of stroke, find average between both hands
        Vector3 leftDir = PositionPreviousFrameLeftHand - PositionThisFrameLeftHand;
        Vector3 rightDir = PositionPreviousFrameRightHand - PositionThisFrameRightHand;
        ForwardDirection.transform.eulerAngles = new Vector3((leftDir.x + rightDir.x)/2, (leftDir.y + rightDir.y) / 2, (leftDir.z + rightDir.z) / 2);
        //Console.WriteLine("x" + (leftAngle.x + rightAngle.x) / 2 + "y" +  (leftAngle.y + rightAngle.y) / 2 + "z" + (leftAngle.z + rightAngle.z) / 2);
        */

        //Add distance moved from both hands. SUbtract it from movement of player
        HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

        if (Time.timeSinceLevelLoad > 1f)
        {
            transform.position += ForwardDirection.transform.forward * HandSpeed * Speed * Time.deltaTime;
        }

        //Reset all positions for the next frame
        PositionPreviousFrameLeftHand = PositionThisFrameLeftHand;
        PositionPreviousFrameRightHand = PositionThisFrameRightHand;
        PlayerPositionPreviousFrame = PlayerPositionThisFrame;

    }
}
