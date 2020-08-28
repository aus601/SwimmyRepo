using TMPro;
using UnityEngine;
using Normal.Realtime;

public class ButtonObject : MonoBehaviour
{
    private Realtime _realtime;
    //Find update local player singleton
    public void Awake()
    {
        _realtime = GetComponent<Realtime>();
    }

    public void LoadGame()
    {
        SceneLoader.Instance.LoadNewScene("GameScene");
        //_realtime.Connect("Game");
    }

    public void SendLocalPlayerName(TextMeshProUGUI nameField)
    {
        UpdateLocalPlayer.Instance.SaveLocalPlayerName( nameField);
    }
}
