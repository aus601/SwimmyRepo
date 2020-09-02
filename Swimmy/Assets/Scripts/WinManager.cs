using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Called from ScoreManager's AddToScore() when a player's score surpasses 20
 */
public class WinManager : Singleton<WinManager>
{
    public Material winSkybox;

    public void playerHasWon(int playerNum)
    {
        RenderSettings.skybox = winSkybox;
        RenderSettings.fogColor = new Color(63f, 127f, 222f);
    }
}
