using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

<<<<<<< Updated upstream
public class WinManager : Singleton<WinManager>
=======
/* Called from ScoreManager's AddToScore() when a player's score surpasses 20
 */
public class WinManager : MonoBehaviour
>>>>>>> Stashed changes
{
    public static WinManager instance;
    public Material winSkybox;
    public Text winSign;

    public bool gameHasWinner = false;

    public void playerHasWon(string playerName)
    {
        RenderSettings.skybox = winSkybox;
        RenderSettings.fogEndDistance = 1000;

        winSign.text = playerName + " has won the game!";
        gameHasWinner = true;
    }

    public void Awake()
    {
        if (instance == null) instance = this;
        else if (instance != this) Destroy(this);
    }
}
