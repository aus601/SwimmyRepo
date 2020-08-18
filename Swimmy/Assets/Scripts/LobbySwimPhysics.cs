using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LobbySwimPhysics : LocomotionProvider
{
    public List<XRController> controllers = null;
    private CharacterController charController;
    private GameObject head;

    public float speed = 1.0f;
    public float gravityMultiplier = 1.0f;

    //Game objects
    //public Rigidbody LeftHand;
    //public Rigidbody RightHand;
    public Rigidbody Body;
    //public Rigidbody cube;

    //Physics
    public float timeToZero = 6f;
    float accelRatePerSec;
    float decelRatePerSec;

    protected override void Awake()
    {
        charController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;

    }

    //Start is called before first frame update
    void Start()
    {
        accelRatePerSec = speed / timeToZero;
        decelRatePerSec = -speed / timeToZero;
        PositionController();
    }

    private void Update()
    {
        PositionController();
        CheckForInput();

    }


    private void PositionController() //to move capsule with camera
    {
        //Get the head in local, playspace ground
        float headHeight = Mathf.Clamp(head.transform.localPosition.y, 1, 2);
        charController.height = headHeight;

        //Cut height in half
        Vector3 newCenter = Vector3.zero;
        newCenter.y = charController.height / 2;

        //Add skin
        newCenter.y += charController.skinWidth;

        //Move capsule in local space
        newCenter.x = head.transform.localPosition.x;
        newCenter.z = head.transform.localPosition.z;
        newCenter.y = head.transform.localPosition.y;

        //Apply to character controller
        charController.center = newCenter;
    }

    private void CheckForInput()
    {
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        //bool isTriggerPressed;
        if (device.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 accel)) //if the controller is moving
        {
            //if (device.TryGetFeatureValue(CommonUsages.triggerButton, out isTriggerPressed) && isTriggerPressed)
            StartMove(accel, device);
        }
        

    }

    private void StartMove(Vector3 accel, InputDevice device) //is called by-frame for each hand
    {
        Vector3 velocity =  -accel ;

        //Debug.Log(velocity);
        if (velocity.magnitude > 2.2) //normal big stroke
        {
            Body.AddForce(new Vector3(velocity.x, 0, velocity.z), ForceMode.Impulse);
            //charController.Move(velocity * Time.deltaTime);

            //Haptics
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    float amplitude = 0.2f ;
                    float duration = 0.5f;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
        else if (velocity.magnitude > 1.5 && velocity.magnitude <= 1.9) //tiny stroke
        {
            //Body.AddForce(velocity / 5, ForceMode.Impulse);
        }

    }
}
