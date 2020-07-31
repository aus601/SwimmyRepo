using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class SwimPhysics : LocomotionProvider
{
    public List<XRController> controllers = null;
    private CharacterController charController;
    private GameObject head;

    public float speed = 1.0f;
    public float gravityMultiplier = 1.0f;

    //Game objects
    public Rigidbody LeftHand;
    public Rigidbody RightHand;
    public Rigidbody Body;
    public Rigidbody cube;

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
        if (device.TryGetFeatureValue(CommonUsages.deviceAcceleration, out Vector3 accel)) //if the controller is moving
        {
            StartMove(accel);
        }
        

    }

    private void StartMove(Vector3 accel) //is called by-frame for each hand
    {
        //speed *= decelRatePerSec;
        //speed = Mathf.Max(speed, 0);

        //Apply speed and move
        //Vector3 movement = speed * -accel;
        //Body.AddForce(accel * Time.deltaTime);
        //charController.Move(movement * Time.deltaTime);

        Vector3 velocity =  -accel ;
        //Body.AddForce(velocity, ForceMode.Impulse);
        charController.Move(velocity * Time.deltaTime);


        /*
        float leftSpeed = leftV.magnitude;
        float rightSpeed = rightV.magnitude;

        Vector3 totalSpeed = leftV + rightV;
        cube.AddForce(totalSpeed * speed);
        */

        /*
        //Apply position to head's forward vector
        Vector3 direction = new Vector3(accel.x, 0, accel.y);
        Vector3 headRotation = new Vector3(head.transform.eulerAngles.x, head.transform.eulerAngles.y, head.transform.eulerAngles.z);

        //Rotate input direction by head rotation
        direction = Quaternion.Euler(headRotation) * direction;
        */
    }
}
