using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Used on the loading sphere to follow player's head
 * Prevents player swimming out of sphere in between scenes
 */
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
