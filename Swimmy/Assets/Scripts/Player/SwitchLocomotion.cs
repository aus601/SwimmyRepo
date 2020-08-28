using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchLocomotion : MonoBehaviour
{
    public GameObject leftHand;
    public GameObject rightHand;

    private void Update()
    {
        if (SceneLoader.Instance.gameIsLoading) // When both: not in loading screen and in game
        {
            this.GetComponent<SwimPhysics>().enabled = true;
            this.GetComponent<LobbySwimPhysics>().enabled = false;

            leftHand.GetComponent<XRInteractorLineVisual>().enabled = false;
            rightHand.GetComponent<XRInteractorLineVisual>().enabled = false;

            this.GetComponent<Rigidbody>().mass = 3;

        }
    }
}
