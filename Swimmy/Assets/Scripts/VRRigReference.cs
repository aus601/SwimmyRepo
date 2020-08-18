using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRRigReference : MonoBehaviour
{
    public static VRRigReference instance;
    public Transform root, head, leftHand, rightHand;
    private void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
}