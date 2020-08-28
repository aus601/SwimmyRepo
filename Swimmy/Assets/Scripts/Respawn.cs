using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
    public float threshold;

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            GetComponent<Rigidbody>().detectCollisions = false;
            transform.position = new Vector3(3.465f, 0.0f, 0.231043f);
            GetComponent<Rigidbody>().detectCollisions = true;
        }
    }
}