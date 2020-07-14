using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ThumbstickLocomotion : LocomotionProvider
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
        //ApplyGravity();

        Vector3 leftV = LeftHand.velocity;
        Vector3 rightV = RightHand.velocity;

        float leftSpeed = leftV.magnitude;
        float rightSpeed = rightV.magnitude;

        Vector3 totalSpeed = leftV + rightV;
        //cube.AddForce(totalSpeed * speed);
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
        foreach(XRController controller in controllers)
        {
            if(controller.enableInputActions) 
            {
                CheckForMovement(controller.inputDevice);
            }
        }
    }

    private void CheckForMovement(InputDevice device)
    {
        if(device.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            StartMove(position);
        }
    }

    private void StartMove(Vector2 position)
    {
        //Apply touch position to head's forward vector
        Vector3 direction = new Vector3(position.x, 0, position.y);
        Vector3 headRotation = new Vector3(head.transform.eulerAngles.x, head.transform.eulerAngles.y, head.transform.eulerAngles.z); 

        //Rotate input direction by head rotation
        direction = Quaternion.Euler(headRotation) * direction;

        //Apply speed and move
        Vector3 movement = direction * speed;
        charController.Move(movement * Time.deltaTime);
    }


    private void ApplyGravity()
    {
        Vector3 gravity = new Vector3(0, Physics.gravity.y * gravityMultiplier, 0);
        gravity.y *= Time.deltaTime;

        charController.Move(gravity * Time.deltaTime);
    }
}
