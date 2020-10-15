using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Set gravity to be normal in Lobby (on land), then floaty in Game (under water)
 */
public class SetGravity : MonoBehaviour
{
    void Awake()
    {
        Physics.gravity = new Vector3(0, -9.8f, 0);
    }

    void Update()
    {
        if (SceneLoader.instance.gameIsLoading)
            Physics.gravity = new Vector3(0, -1.2f, 0);
    }
}
