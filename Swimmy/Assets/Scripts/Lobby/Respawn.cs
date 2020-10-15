using UnityEngine;
using System.Collections;

/* Respawns an object in it's original position once it falls below Kill Z
 * ONLY used on oxygenTank in Lobby scene
 */
public class Respawn : MonoBehaviour
{
    public float threshold;
    public Vector3 startingPos;

    private void Awake()
    {
        startingPos = transform.position;
    }

    void FixedUpdate()
    {
        if (transform.position.y < threshold)
        {
            RespawnNow();
        }
    }

    public void RespawnNow()
    {
        GetComponent<Rigidbody>().detectCollisions = false;
        transform.position = startingPos; // new Vector3(3.465f, 0.0f, 0.231043f);
        GetComponent<Rigidbody>().detectCollisions = true;
    }
}