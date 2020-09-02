using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/* Get the camera object from the XR Rig in Persistent Scene, so it can be accessed within other scenes
 */
public class FindCamera : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Canvas>().worldCamera = VRRigReference.instance.head.GetComponent<Camera>();

    }
}
