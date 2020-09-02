using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/* Swimming locomotion for the players
 * 
 * Activated only in Game scene
 */
public class SwimPhysics : LocomotionProvider
{
    public List<XRController> controllers = null;
    private CharacterController charController;
    private GameObject head;

    public float speed = 1.0f;
    public float gravityMultiplier = 1.0f;

    public Rigidbody Body;

    protected override void Awake()
    {
        charController = GetComponent<CharacterController>();
        head = GetComponent<XRRig>().cameraGameObject;

    }

    //Start is called before first frame update
    void Start()
    {
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
        //if the controller is moving
        if (device.TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 accel)) 
        {
            StartMove(accel, device);
        }
    }

    //is called by-frame for each hand
    private void StartMove(Vector3 accel, InputDevice device) 
    {
        //Invert the velocity to move opposite direction of stroke
        Vector3 velocity =  -accel;

        //Restrict a stroke to only a speed abov e 1.5 to avoid jerking motion
        if (velocity.magnitude > 1.9) //normal big stroke
        {
            Body.AddForce(velocity, ForceMode.Impulse);

            //Haptics
            UnityEngine.XR.HapticCapabilities capabilities;
            if (device.TryGetHapticCapabilities(out capabilities))
            {
                if (capabilities.supportsImpulse)
                {
                    uint channel = 0;
                    float amplitude = 0.3f ;
                    float duration = 0.7f;
                    device.SendHapticImpulse(channel, amplitude, duration);
                }
            }
        }
        else if (velocity.magnitude > 1.5 && velocity.magnitude <= 1.9) //tiny stroke
        {
            Body.AddForce(velocity / 5, ForceMode.Impulse);
        }
    }
}
