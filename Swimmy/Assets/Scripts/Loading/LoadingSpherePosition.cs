using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSpherePosition : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (this.isActiveAndEnabled)
            transform.position = player.transform.position;
    }
}
