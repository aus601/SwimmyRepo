using TMPro;
using UnityEngine;
using Normal.Realtime;

/* The ENTER button
 * Used to save player name from input field and load game
 */
public class ButtonObject : MonoBehaviour
{
    private Realtime _realtime;
    
    public void Awake()
    {
        _realtime = GetComponent<Realtime>();
    }

    public void LoadGame()
    {
        SceneLoader.Instance.LoadNewScene("GameScene");
    }

    public void SendLocalPlayerName(TextMeshProUGUI nameField)
    {
        UpdateLocalPlayer.Instance.SaveLocalPlayerName( nameField); // POSSIBLE BUG HERE
    }
}
